using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Comment
{
    public class AddCommentDTO
    {
        public string Text { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
