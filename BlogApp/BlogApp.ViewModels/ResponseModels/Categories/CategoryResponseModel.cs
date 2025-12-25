using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels.ResponseModels.Categories
{
    public class CategoryResponseModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
