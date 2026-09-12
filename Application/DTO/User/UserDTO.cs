using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime? ActivatedAt { get; set; }
    }
}
