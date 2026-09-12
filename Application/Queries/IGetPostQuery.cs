using Application.DTO.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetPostQuery:IQuery<int, PostDTO>
    {
    }
}
