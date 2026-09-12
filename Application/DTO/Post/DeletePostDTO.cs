using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Post
{
    public class DeletePostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DeletedAt {  get; set; }
    }
}
