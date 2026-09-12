using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IUseCase
    {
        string Name { get; }  
        string Id { get; }
    }
}
