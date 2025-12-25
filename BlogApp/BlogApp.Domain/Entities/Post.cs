using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class Post : BaseEntity
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }


    }
}
