using Application;
using Application.DTO;
using Application.DTO.Post;
using Application.Exceptions;
using Application.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Queries
{
    public class EfGetPostQuery : EfUseCase,IGetPostQuery
    {

        private readonly IApplicationUser _user;
        public EfGetPostQuery(BlogDbContext context, IApplicationUser user)
            :base(context)
        {
            _user = user;
        }
        public string Name => "Prikaz posta";

        public string Id => "get-post";

        public Task<PostDTO> ExecuteAsync(int id)
        {
            var userId = _user.Id;
            var post=ctx.Posts.Where(p=>p.Id== id && p.DeletedAt == null).Select(p=>new PostDTO
            {
                Id= p.Id,
                Author=p.User.Username,
                AuthorId=p.UserId,
                Description= p.Description,
                Title= p.Title,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                AverageRating = p.Ratings.Average(r => (double?)r.Value) ?? 0,
                RatingsCount = p.Ratings.Count,
                MyRating = p.Ratings.Where(r => r.UserId == userId).Select(r => r.Value).FirstOrDefault(),
                Image=p.Images.Select(
                    i=>i.Path).FirstOrDefault(),
            }).FirstOrDefaultAsync();
            
            if(post == null)
            {
                throw new NotFoundException("Post");
            }

            return post;

        }
    }
}
