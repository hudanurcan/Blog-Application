using AutoMapper;
using BlogApp.Application.DtoClasses;
using BlogApp.Application.Exceptions.Abstract;
using BlogApp.Application.Exceptions.Concrete;
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
    //public class PostManager(IPostRepository repository, IMapper mapper, IErrorHandler errorHandler) : BaseManager<PostDto, Post>(repository, mapper, errorHandler), IPostManager
    //{
    //    private readonly IPostRepository _repository = repository;
    //}
    public class PostManager : BaseManager<PostDto, Post>, IPostManager
    {
        private readonly IPostRepository _repository;
        private readonly IRepository<Category> _categoryRepository; // Kategori kontrolü için
        private readonly IRepository<Tag> _tagRepository;           // Etiket kontrolü için
        private readonly IErrorHandler _errorHandler;
        private readonly IMapper _mapper;

        public PostManager(IPostRepository repository,
                           IRepository<Category> categoryRepository,
                           IRepository<Tag> tagRepository,
                           IMapper mapper,
                           IErrorHandler errorHandler) : base(repository, mapper, errorHandler)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _errorHandler = errorHandler;
            _mapper = mapper;
        }

        public override async Task CreateAsync(PostDto postDto)
        {
            await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                // 1. İŞ KURALI (Madde 2.1 - A): Published ise Title ve Content zorunlu
                if (postDto.IsPublished)
                {
                    if (string.IsNullOrWhiteSpace(postDto.Title) || string.IsNullOrWhiteSpace(postDto.Content))
                        throw new CustomException("Yayımlanan bir yazının başlığı ve içeriği boş olamaz!", 400);
                }

                // 2. İŞ KURALI: Başlık uzunluk sınırı kontrolü (Örn: 5-200 karakter)
                if (postDto.Title.Length < 5 || postDto.Title.Length > 200)
                    throw new CustomException("Başlık 5 ile 200 karakter arasında olmalıdır.", 400);

                // 3. İLİŞKİ YÖNETİMİ: Kategori ve Tag var mı kontrol et
                var category = await _categoryRepository.GetByIdAsync(postDto.CategoryId);
                if (category == null) throw new CustomException("Seçilen kategori bulunamadı!", 404);

                var tag = await _tagRepository.GetByIdAsync(postDto.TagId);
                if (tag == null) throw new CustomException("Seçilen etiket bulunamadı!", 404);

                // 4. MAPPING VE KAYIT
                Post post = _mapper.Map<Post>(postDto);
                post.Status = Domain.Enums.DataStatus.Inserted;
                post.CreatedAt = DateTime.Now;

                // Many-to-Many ilişkisini kur (Ara tabloları EF otomatik doldurur)
                post.Categories = new List<Category> { category };
                post.Tags = new List<Tag> { tag };

                await _repository.CreateAsync(post);
            });
        }
    }
}
