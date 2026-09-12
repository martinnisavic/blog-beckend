using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected readonly BlogDbContext ctx;

        protected EfUseCase (BlogDbContext context)
        {
            ctx= context;
        }
    }
}
