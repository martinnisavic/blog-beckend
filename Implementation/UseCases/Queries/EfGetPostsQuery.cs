using Application;
using Application.DTO.Paging;
using Application.DTO;
using Application.DTO.Post;
using Application.Queries;
using DataAccess;
using Domain.Entities;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Queries
{
    public class EfGetPostsQuery : EfUseCase, IGetPostsQuery
    {
        private readonly IApplicationUser _user;
        public EfGetPostsQuery(BlogDbContext context, IApplicationUser user)
            :base(context)
        {
            _user = user;
        }

        public string Name => "Listing posts";
        public string Id => "get-posts";

        public async Task<PagedResponse<PostDTO>> ExecuteAsync(PostSearch search)
        {
            var userId = _user.Id;
            IQueryable<PostEntity> query = ctx.Posts.Where(p=>p.DeletedAt==null);

            if(!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.Contains(search.Keyword) || x.Description.Contains(search.Keyword));
            }

            return await query.PaginateAsync(search, p => new PostDTO
            {
                Id=p.Id,
                Title=p.Title,
                Description=p.Description,
                Author=p.User.Username,
                AuthorId=p.User.Id,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                AverageRating = p.Ratings.Average(r => (double?)r.Value) ?? 0,
                RatingsCount = p.Ratings.Count,
                MyRating = p.Ratings.Where(r => r.UserId == userId).Select(r => r.Value).FirstOrDefault(),
                Image = p.Images.Select(i => i.Path).FirstOrDefault(),
                CreatedAt =p.CreatedAt
            });

        }


    }
}
