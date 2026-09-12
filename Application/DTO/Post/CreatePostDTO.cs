using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Post
{
    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
