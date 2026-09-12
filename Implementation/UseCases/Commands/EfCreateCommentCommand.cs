using Application;
using Application.Commands;
using Application.DTO;
using Application.DTO.Comment;
using Application.Exceptions;
using DataAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Commands
{
    public class EfCreateCommentCommand : EfUseCase, ICreateCommentCommand
    {
        private readonly IApplicationUser _user;
        public EfCreateCommentCommand(BlogDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public string Name => "Add Comment";

        public string Id => "create-comment";

        public async Task ExecuteAsync(AddCommentDTO data)
        {
            var post=await ctx.Posts.AnyAsync(p=>p.Id==data.PostId);
            if(!post)
            {
                throw new NotFoundException("Post");
            }

            var comment = new CommentEntity
            {
                Text = data.Text,
                PostId = data.PostId,
                CreatedAt = DateTime.UtcNow,
                AuthorId= _user.Id,
            };
            ctx.Comments.Add(comment);
            await ctx.SaveChangesAsync();
        }
    }
}
