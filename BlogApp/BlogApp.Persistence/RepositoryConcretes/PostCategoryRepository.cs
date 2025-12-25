using BlogApp.Contract.RepositoryInterfaces;
using BlogApp.Domain.Entities;
using BlogApp.Persistence.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.RepositoryConcretes
{
    public class PostCategoryRepository(MyContext context) : BaseRepository<PostCategory>(context), IPostCategoryRepository
    {
    }
}
