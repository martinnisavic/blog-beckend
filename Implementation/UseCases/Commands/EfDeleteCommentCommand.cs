using Application;
using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Commands
{
    public class EfDeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {
        private readonly IApplicationUser _user;
        public EfDeleteCommentCommand(BlogDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public string Name => "Delete Comment";

        public string Id => "delete-comment";

        public async Task ExecuteAsync(int id)
        {
            var comment = await ctx.Comments.FirstOrDefaultAsync(c => c.Id == id && c.DeletedAt == null);

            if(comment==null)
            {
                throw new DirectoryNotFoundException("Comment");
            }

            if (comment.AuthorId != _user.Id && _user.Role != "Admin")
            {
                throw new UnAuthorizedUseCaseException(_user.Username, Name);
            }
            comment.DeletedAt = DateTime.UtcNow;   
            await ctx.SaveChangesAsync();

        }
    }
}
