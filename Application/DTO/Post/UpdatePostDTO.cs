using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Post
{
    public class UpdatePostDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
