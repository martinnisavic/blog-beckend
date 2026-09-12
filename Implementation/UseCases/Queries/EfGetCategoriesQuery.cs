using Application.DTO.Category;
using Application.Queries;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases.Queries
{
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public EfGetCategoriesQuery(BlogDbContext context) : base(context)
        {
        }

        public string Name => "Prikaz kategorija";

        public string Id => "get-categories";

        public async Task<List<CategoryDTO>> ExecuteAsync(int request)
        {
            return await ctx.Categories
                .Where(c => c.DeletedAt == null)
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }
    }
}
