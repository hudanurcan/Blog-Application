using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DtoClasses
{
    public class PostTagDto : BaseDto
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
