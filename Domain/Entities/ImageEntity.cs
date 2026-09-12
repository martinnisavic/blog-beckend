using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ImageEntity:BaseEntity
    {
        public string Path {  get; set; }
        public int PostId { get; set; }
        public virtual PostEntity Post { get; set; }
    }
}
