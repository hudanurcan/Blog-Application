using BlogApp.Application.DtoClasses;
using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.ManagerInterfaces
{
    public interface ICategoryManager : IManager<CategoryDto, Category>
    {
    }
}
