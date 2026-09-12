using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class RoleEntity:BaseEntity
    {
        public string Name {  get; set; } = string.Empty;
        public virtual List<UserEntity> Users { get ; set; }
        public virtual List<RoleUseCaseEntity> RoleUseCases { get ; set; }
    }
}
