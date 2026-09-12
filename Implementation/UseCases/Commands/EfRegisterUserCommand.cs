using Application.Commands;
using Application.Services;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.UseCases.Validators;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Application.DTO.User;

namespace Implementation.UseCases.Commands
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _emailSender;
        public EfRegisterUserCommand(BlogDbContext context, RegisterUserValidator validator, IEmailSender emailSender) :base(context) 
        {
            _emailSender = emailSender;
            _validator= validator;
        }
        
        public string Name => "Registracija korisnika";

        public string Id => "register";

        public async Task ExecuteAsync(UserRegisterDTO data)
        {
            await _validator.ValidateAndThrowAsync(data);
            string hash = BCrypt.Net.BCrypt.HashPassword(data.Password);
            var role = await ctx.Roles.FirstAsync(r => r.Name == "User");

            var new_user = new UserEntity
            {
                Name = data.Name,
                Surname = data.Surname,
                Username = data.Username,
                Email = data.Email,
                Phone = data.Phone,
                Password = hash,
                RoleId = role.Id,
                ActivationCode = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow
            };

            ctx.Users.Add(new_user);
            await ctx.SaveChangesAsync();

            await _emailSender.SendEmailAsync(
    new_user.Email,
    "Aktivacija naloga",
    $"Zdravo {new_user.Name}, aktiviraj nalog klikom: " +
    $"<a href='http://localhost:4200/activate/{new_user.ActivationCode}'>Aktiviraj</a>");
        }
    }
}
