using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Paging
{
    public class PagedResponse<T>
    {
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
        public int TotalCount { get; set; }
        public int PagesCount => (int)Math.Ceiling((double)TotalCount / PerPage);
        public IEnumerable<T> Items { get; set; }
    }
}
