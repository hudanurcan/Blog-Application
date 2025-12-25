using BlogApp.Contract.RepositoryInterfaces;
using BlogApp.Persistence.RepositoryConcretes;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.DependencyResolvers
{
 
    public static class RepositoryResolver
    {
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IPostTagRepository, PostTagRepository>();
            services.AddScoped<IPostCategoryRepository, PostCategoryRepository>();



        }
    }
}
