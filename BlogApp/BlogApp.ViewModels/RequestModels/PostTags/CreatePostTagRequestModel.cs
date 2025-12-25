using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels.RequestModels.PostTags
{
    public class CreatePostTagRequestModel
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
