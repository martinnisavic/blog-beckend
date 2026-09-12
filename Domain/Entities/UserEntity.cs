using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public string ActivationCode { get; set; }
        public DateTime? ActivatedAt { get; set; }

        public virtual RoleEntity Role { get; set; }
        public virtual List<PostEntity> Posts { get; set; }
    }
}
