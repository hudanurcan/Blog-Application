using AutoMapper;
using BlogApp.Application.DtoClasses;
using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlogApp.Application.MappingProfiles
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<TagDto, Tag>().ReverseMap();
            CreateMap<PostTagDto, PostTag>().ReverseMap();
            CreateMap<PostCategoryDto, PostCategory>().ReverseMap();
        }
    }
}
