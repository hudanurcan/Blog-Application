using AutoMapper;
using BlogApp.Application.DtoClasses;
using BlogApp.Application.Exceptions.Abstract;
using BlogApp.Application.ManagerInterfaces;
using BlogApp.Contract.RepositoryInterfaces;
using BlogApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.InnerInfrastructure.ManagerConcretes
{
    public class PostTagManager(IPostTagRepository repository, IMapper mapper, IErrorHandler errorHandler) : BaseManager<PostTagDto, PostTag>(repository, mapper, errorHandler), IPostTagManager
    {
        private readonly IPostTagRepository _repository = repository;
    }
}
