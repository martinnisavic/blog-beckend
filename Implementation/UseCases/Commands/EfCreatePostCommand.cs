using Application;
using Application.Commands;
using Application.DTO.Post;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.UseCases.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Commands
{
    public class EfCreatePostCommand : EfUseCase,ICreatePostCommand
    {
        private readonly IApplicationUser _user;
        private readonly CreatePostValidator _validator;
        public EfCreatePostCommand(BlogDbContext context, IApplicationUser user, CreatePostValidator validator)
        :base(context)
        {
            _user= user;
            _validator = validator;
        }
        public string Name => "Post creation";

        public string Id => "create-post";

        public async Task ExecuteAsync(CreatePostDTO data)
        {
            await _validator.ValidateAndThrowAsync(data);
            var post = new PostEntity
            {
                UserId = _user.Id,
                Description = data.Description,
                Title = data.Title,
                CategoryId = data.CategoryId,
                CreatedAt = DateTime.UtcNow,
            };

            if (!string.IsNullOrEmpty(data.Image))
            {
                post.Images = new List<ImageEntity>
                {
                    new ImageEntity { Path = data.Image, CreatedAt = DateTime.UtcNow }
                };
            }

            ctx.Posts.Add(post);
            await ctx.SaveChangesAsync();
        }
    }
}
