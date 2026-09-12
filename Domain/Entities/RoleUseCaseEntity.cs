using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class RoleUseCaseEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }

        public int UseCaseId { get; set; }
        public virtual UseCaseEntity UseCase { get; set; }
    }
}
