using Application.DTO.Rating;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Validators
{
    public class RatePostValidator : AbstractValidator<RatePostDTO>
    {
        public RatePostValidator(BlogDbContext context)
        {
            RuleFor(x => x.Value)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");

            RuleFor(x => x.PostId)
                .MustAsync(async (id, ct) => await context.Posts.AnyAsync(p => p.Id == id && p.DeletedAt == null, ct))
                .WithMessage("Post does not exist");
        }
    }
}
