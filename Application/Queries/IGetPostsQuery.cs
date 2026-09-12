using Application.DTO.Paging;
using Application.DTO.Post;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetPostsQuery: IQuery<PostSearch, PagedResponse<PostDTO>>
    {
    }
}
