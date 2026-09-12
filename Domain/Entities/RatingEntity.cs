using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class RatingEntity : BaseEntity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int Value { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual PostEntity Post { get; set; }
    }
}
