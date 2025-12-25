using AutoMapper;
using BlogApp.Application.DtoClasses;
using BlogApp.ViewModels.RequestModels.Categories;
using BlogApp.ViewModels.RequestModels.Posts;
using BlogApp.ViewModels.RequestModels.Tags;
using BlogApp.ViewModels.ResponseModels.Categories;
using BlogApp.ViewModels.ResponseModels.Posts;
using BlogApp.ViewModels.ResponseModels.Tags;


namespace BlogApp.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            CreateMap<CreateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateCategoryRequestModel,CategoryDto>();
            CreateMap<CategoryDto, CategoryResponseModel>();

            CreateMap<CreateTagRequestModel, TagDto>();
            CreateMap<UpdateTagRequestModel, TagDto>();
            CreateMap<TagDto, TagResponseModel>();

            CreateMap<CreatePostRequestModel, PostDto>();
            CreateMap<UpdatePostRequestModel, PostDto>();
            CreateMap<PostDto, PostResponseModel>();

        }
    }
}
