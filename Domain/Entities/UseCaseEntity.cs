using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UseCaseEntity:BaseEntity
    {
        public string Name {  get; set; }

        public virtual List<RoleUseCaseEntity> RoleUseCases { get; set; }
    }
}
