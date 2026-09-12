using Application.DTO.Post;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostDTO>
    {
        public CreatePostValidator(BlogDbContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(5).WithMessage("Title must be at least 5 characters")
                .MaximumLength(200).WithMessage("Title can have at most 200 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MinimumLength(10).WithMessage("Description must be at least 10 characters")
                .MaximumLength(2000).WithMessage("Description can have at most 2000 characters");

            RuleFor(x => x.CategoryId)
                .MustAsync(async (id, ct) => await context.Categories.AnyAsync(c => c.Id == id && c.DeletedAt == null, ct))
                .WithMessage("Selected category does not exist");
        }
    }
}
