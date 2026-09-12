using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IQuery<TParam, TResponse> : IUseCase
    {
        Task<TResponse> ExecuteAsync(TParam request);
    }
}
