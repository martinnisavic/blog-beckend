using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Comment
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
