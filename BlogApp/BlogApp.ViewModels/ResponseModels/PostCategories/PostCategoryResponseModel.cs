using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels.ResponseModels.PostCategories
{
    public class PostCategoryResponseModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }
    }
}
