using Application;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using Application.DTO.Post;

namespace Implementation.UseCases.Commands
{
    public class EfDeletePostCommand : EfUseCase, IDeletePostCommand
    {
        public readonly IApplicationUser _user;
        public EfDeletePostCommand(IApplicationUser user, BlogDbContext context) :base(context)
        {
            _user = user;
        }

        public string Name => "Delete post";
        public string Id => "delete-post";

        public async Task ExecuteAsync(int id)
        {
            var post=await ctx.Posts.FirstOrDefaultAsync(p=>p.Id == id && p.DeletedAt==null);

            if (post == null)
            {
                throw new NotFoundException("Post");
            }

            if(post.UserId!=_user.Id && _user.Role!="Admin")
            {
                throw new UnAuthorizedUseCaseException(_user.Username, Name);
            }

            post.DeletedAt = DateTime.UtcNow;      
            await ctx.SaveChangesAsync();
        }

        
    }
}
