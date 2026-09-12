using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CommentEntity:BaseEntity
    {
        public string Text { get; set; }
        public int AuthorId { get; set; }
        public int PostId { get; set; }

        public virtual UserEntity Author { get; set; }
        public virtual PostEntity Post { get; set; }
    }
}
