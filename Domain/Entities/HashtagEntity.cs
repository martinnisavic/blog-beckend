using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class HashtagEntity : BaseEntity
    {
        public string Value { get; set; }
        public virtual List<PostEntity> Posts { get; set; }  
    }
}
