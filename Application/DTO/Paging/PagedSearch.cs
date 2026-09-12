using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Paging
{
    public class PagedSearch
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;
    }
}
