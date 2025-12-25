using BlogApp.Domain.Entities;
using BlogApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contract.RepositoryInterfaces
{
    public interface IPostRepository : IRepository<Post>
    {

    }
}
