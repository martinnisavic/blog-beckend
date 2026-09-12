using Application.Commands;
using Application.Exceptions;
using Castle.Components.DictionaryAdapter.Xml;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Commands
{
    public class EfActivateAccountCommand : EfUseCase, IActivateAccountCommand
    {
        public EfActivateAccountCommand(BlogDbContext context) : base(context)
        {
        }

        public string Name => "Account activation";

        public string Id => "account-activate";

         public async Task ExecuteAsync(string code)
        {
            var user = await ctx.Users.FirstOrDefaultAsync(u => u.ActivationCode == code);

            if (user == null)
            {
                throw new NotFoundException("User activation not existing");
            }
            if(user.ActivatedAt.HasValue)
            {
                throw new NotFoundException("Activation code already activated");
            }

            user.ActivatedAt = DateTime.UtcNow;
            user.ActivationCode = null;
            await ctx.SaveChangesAsync();

        
    }
    }
}
