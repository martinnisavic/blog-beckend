using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PostEntity:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public virtual List<CommentEntity> Comments { get; set; }
        public virtual List<ImageEntity> Images { get; set; }
        public virtual List<HashtagEntity> Hashtags { get; set; }
        public virtual List<RatingEntity> Ratings { get; set; }
    }
}
