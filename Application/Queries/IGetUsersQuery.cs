using Application.DTO.Paging;
using Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetUsersQuery: IQuery<UserSearch,PagedResponse<UserDTO>>
    {
    }
}
