using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public class PostCategory : BaseEntity
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Post Post { get; set; }
    }
}
