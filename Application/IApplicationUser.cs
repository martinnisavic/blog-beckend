using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IApplicationUser
    {
        int Id { get; }
        string Email { get; }
        string Username { get; }
        string Role { get; }
        IEnumerable<string> AllowedUseCases { get; }
    }
}
