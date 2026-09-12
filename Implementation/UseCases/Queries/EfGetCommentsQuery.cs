using Application.DTO.Comment;
using Application.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Queries
{
    public class EfGetCommentsQuery : EfUseCase, IGetCommentsQuery
    {
        public EfGetCommentsQuery(BlogDbContext context) : base(context)
        {
        }

        public string Name => "Prikaz komentara";

        public string Id => "get-comments";
        public async Task<List<CommentDTO>> ExecuteAsync(int id)
        {
            return await ctx.Comments.Where(c => c.PostId == id && c.DeletedAt == null).Select(c => new CommentDTO
            {
                Id = c.Id,
                Author = c.Author.Username,
                Text = c.Text,
                AuthorId=c.Author.Id,
                CreatedAt = c.CreatedAt
            }).ToListAsync();
        }
    }
}
