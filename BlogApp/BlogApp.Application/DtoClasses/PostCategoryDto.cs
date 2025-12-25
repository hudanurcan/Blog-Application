using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DtoClasses
{
    public class PostCategoryDto : BaseDto
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
    }
}
