using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface ICommand<TRequest> : IUseCase
    {
        Task ExecuteAsync(TRequest data);
    }
}