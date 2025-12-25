using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels.RequestModels.PostCategories
{
    public class CreatePostCategoryRequestModel
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
    }
}
