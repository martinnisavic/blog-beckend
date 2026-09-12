using Application;
using Application.Commands;
using Application.DTO.Rating;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.UseCases.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Commands
{
    public class EfRatePostCommand : EfUseCase, IRatePostCommand
    {
        private readonly IApplicationUser _user;
        private readonly RatePostValidator _validator;
        public EfRatePostCommand(BlogDbContext context, IApplicationUser user, RatePostValidator validator)
            : base(context)
        {
            _user = user;
            _validator = validator;
        }

        public string Name => "Rate post";

        public string Id => "rate-post";

        public async Task ExecuteAsync(RatePostDTO data)
        {
            await _validator.ValidateAndThrowAsync(data);

            var rating = await ctx.Ratings
                .FirstOrDefaultAsync(r => r.PostId == data.PostId && r.UserId == _user.Id);

            if (rating == null)
            {
                ctx.Ratings.Add(new RatingEntity
                {
                    PostId = data.PostId,
                    UserId = _user.Id,
                    Value = data.Value,
                    CreatedAt = DateTime.UtcNow
                });
            }
            else
            {
                rating.Value = data.Value;
                rating.UpdatedAt = DateTime.UtcNow;
            }

            await ctx.SaveChangesAsync();
        }
    }
}
