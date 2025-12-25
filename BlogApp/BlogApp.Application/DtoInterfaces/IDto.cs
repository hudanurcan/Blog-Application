using BlogApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DtoInterfaces
{
    public interface IDto
    {
        public int Id { get; set; }
        public DataStatus Status { get; set; }

    }
}
