using Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IRegisterUserCommand : ICommand<UserRegisterDTO>
    {
    }
}
