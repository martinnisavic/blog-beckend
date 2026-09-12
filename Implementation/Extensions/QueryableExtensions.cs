using Application.DTO.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResponse<TDto>> PaginateAsync<TEntity, TDto>(
            this IQueryable<TEntity> query,
            PagedSearch search,
            Expression<Func<TEntity, TDto>> transform)
        {
            var totalCount = await query.CountAsync();
            var skip = (search.Page - 1) * search.PerPage;
            var items = await query
                .Skip(skip)
                .Take(search.PerPage)
                .Select(transform)
                .ToListAsync();

            return new PagedResponse<TDto>
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = totalCount,
                Items = items
            };
        }
    }
}
