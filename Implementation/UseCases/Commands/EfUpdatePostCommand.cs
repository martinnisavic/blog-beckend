using Application.Commands;
using Application.DTO.Post;
using Application.Exceptions;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;     
using Application;

namespace Implementation.UseCases.Commands
{
    public class EfUpdatePostCommand : EfUseCase, IUpdatePostCommand
    {
        private readonly IApplicationUser _user;
        public EfUpdatePostCommand(BlogDbContext context, IApplicationUser user) : base(context)
        {
            _user= user;
        }

        public string Name => "Update post";

        public string Id => "update-post";

        public async Task ExecuteAsync(UpdatePostDTO data)
        {
            var post =await ctx.Posts.FirstOrDefaultAsync(p => p.Id == data.Id);
            if (post == null)
            {
                throw new NotFoundException("Post");
            }
            if(post.UserId!=_user.Id)
            {
                throw new UnAuthorizedUseCaseException(_user.Username, Name);
            }

            if(!string.IsNullOrEmpty(data.Description))
            {
                post.Description=data.Description;
            }

            if (!string.IsNullOrEmpty(data.Title))
            {
                post.Title = data.Title;
            }

            if (data.CategoryId != 0)
            {
                bool exists = await ctx.Categories.AnyAsync(c => c.Id == data.CategoryId && c.DeletedAt == null);
                if (!exists)
                {
                    throw new NotFoundException("Category");
                }
                post.CategoryId = data.CategoryId;
            }

            post.UpdatedAt = DateTime.UtcNow;
            await ctx.SaveChangesAsync();
        }

    }
    }
    

