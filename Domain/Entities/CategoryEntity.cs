using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<PostEntity> Posts { get; set; }
    }
}
