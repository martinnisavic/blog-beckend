using Application.DTO.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public interface IGetCategoriesQuery : IQuery<int, List<CategoryDTO>>
    {
    }
}
