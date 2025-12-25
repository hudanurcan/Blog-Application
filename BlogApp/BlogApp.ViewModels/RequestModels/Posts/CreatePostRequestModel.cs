using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels.RequestModels.Posts
{
    public class CreatePostRequestModel
    {

        public string Title { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public bool IsPublished { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }
    }
}
