using BlogApp.Domain.Enums;
using BlogApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DataStatus Status { get; set; }

    }
}
