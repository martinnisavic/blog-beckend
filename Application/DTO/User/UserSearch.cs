using Application.DTO.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.User
{
    public class UserSearch:PagedSearch
    {
        public string Keyword { get; set; }
    }
}
