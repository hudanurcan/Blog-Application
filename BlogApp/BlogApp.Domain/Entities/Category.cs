using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class Category :BaseEntity
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }

    }
}
