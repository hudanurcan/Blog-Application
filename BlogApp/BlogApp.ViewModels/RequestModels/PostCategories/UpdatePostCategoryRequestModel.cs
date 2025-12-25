using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels.RequestModels.PostCategories
{
    public class UpdatePostCategoryRequestModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CategoryId { get; set; }
    }
}
