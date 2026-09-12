using Application.DTO.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IUpdatePostCommand:ICommand<UpdatePostDTO>
    {
    }
}
