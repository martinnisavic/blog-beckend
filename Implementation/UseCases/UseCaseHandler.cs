using Application;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases
{
    public class UseCaseHandler
    {
        private readonly IApplicationUser _user;
        public UseCaseHandler(IApplicationUser user)
        {
            _user= user;
        }

        private void HandleAuthorization(IUseCase useCase)
        {
            if(!_user.AllowedUseCases.Contains(useCase.Id))
            {
                throw new UnAuthorizedUseCaseException(_user.Username, useCase.Name);
            }
        }
        public async Task ExecuteCommandAsync<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            HandleAuthorization(command);
            await command.ExecuteAsync(data);
        }
            public async Task<TResult> ExecuteQueryAsync<TParam, TResult>(IQuery<TParam, TResult> query, TParam request)
            where TResult : class
        {
            HandleAuthorization(query);
            return await query.ExecuteAsync(request);
        }
    }    
    
}
