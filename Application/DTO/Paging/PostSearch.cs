using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Paging
{
    public class PostSearch:PagedSearch
    {
        public string Keyword { get; set; }
    }
}
