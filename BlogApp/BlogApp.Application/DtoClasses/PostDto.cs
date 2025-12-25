using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DtoClasses
{
    public class PostDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }
        public List<Category> Categories { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
