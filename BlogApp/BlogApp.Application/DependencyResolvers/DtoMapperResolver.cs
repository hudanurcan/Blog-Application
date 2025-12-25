using BlogApp.Application.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.DependencyResolvers
{
    public static class DtoMapperResolver
    {
      
        public static void AddDtoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoMappingProfile));
        }
    }
}
