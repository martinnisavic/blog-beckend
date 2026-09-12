using Application.DTO.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetCommentsQuery:IQuery<int,List<CommentDTO>>
    {
    }
}
