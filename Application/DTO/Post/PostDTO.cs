using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Post
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double AverageRating { get; set; }
        public int RatingsCount { get; set; }
        public int MyRating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
