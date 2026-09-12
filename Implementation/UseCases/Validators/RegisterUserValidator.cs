using Application.DTO.User;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Validators
{
    public class RegisterUserValidator : AbstractValidator<UserRegisterDTO>
    {
        public RegisterUserValidator(BlogDbContext context)
        {
            RuleFor(x => x.Name)
                .Matches(@"^[A-ZČĆŠĐ][a-zšđčć]+(\s[A-ZČĆŠĐ][a-zšđčć]+|-[A-ZČĆŠĐ][a-zšđčć]+)*$")
                .WithMessage("Name must only contain letters and first letter must be big letter")
                .MaximumLength(50)
                .NotEmpty().WithMessage("Name is required");
            RuleFor(x=>x.Surname)
                .Matches(@"^[A-ZČĆŠĐ][a-zšđčć]+(\s[A-ZČĆŠĐ][a-zšđčć]+|-[A-ZČĆŠĐ][a-zšđčć]+)*$")
                .WithMessage("Surname must only contain letters and first letter must be big letter")
                .MaximumLength(50)
                .NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Email)
                .Matches(@"^[a-z\d\.]{3,30}\@(gmail\.com|ict\.edu\.rs|yahoo\.com)$")
                .WithMessage("Email must only contain combination of letters or numbers or . or _")
                .MustAsync(async(email,ct) => !await context.Users.AnyAsync(u => u.Email == email, ct))
                .WithMessage("Email is in use")
                .NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Username)
                .Matches(@"^[A-Za-z\d\._]{3,30}$")
                .WithMessage("Username must only contain letters or numbers or . or _")
                .MustAsync(async(username, ct) => !await context.Users.AnyAsync(u => u.Username == username, ct))
                .WithMessage("Username is in use")
                .NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Phone)
                .Matches(@"^(\+381[6][0-9]|\+381\s[6][0-9]|[0][6][0-9])(\s\d{2}\s\d{2}\s\d{3}|-\d{2}-\d{2}-\d{3}|\d{7})$")
                .WithMessage("Phone must be in format +381xxxxxxxxx or 06xxxxxxxxx")
                .NotEmpty().WithMessage("Phone is required");
            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,64}$")
                .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character and be at least 8 characters long")
                .NotEmpty().WithMessage("Password is required");

        }
    }
}
