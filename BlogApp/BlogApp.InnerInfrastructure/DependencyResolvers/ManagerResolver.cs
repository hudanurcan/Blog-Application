
using BlogApp.Application.ManagerInterfaces;
using BlogApp.InnerInfrastructure.ManagerConcretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.InnerInfrastructure.DependencyResolvers
{

    public static class ManagerResolver
    {
        public static void AddManagerService(this IServiceCollection services)
        {

            services.AddScoped<ICategoryManager,CategoryManager>();
            services.AddScoped<IPostManager,PostManager>();
            services.AddScoped<ITagManager,TagManager>();
            services.AddScoped<IPostTagManager,PostTagManager>();
            services.AddScoped<IPostCategoryManager, PostCategoryManager>();
    
        }
    }
}
