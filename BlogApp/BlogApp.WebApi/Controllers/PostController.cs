using AutoMapper;
using BlogApp.Application.DtoClasses;
using BlogApp.Application.Exceptions.Abstract;
using BlogApp.Application.Exceptions.Concrete;
using BlogApp.Application.ManagerInterfaces;
using BlogApp.Contract.RepositoryInterfaces;
using BlogApp.Domain.Entities;
using BlogApp.ViewModels.RequestModels.Posts;
using BlogApp.ViewModels.ResponseModels.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostManager _postManager;
        private readonly IMapper _mapper;
        private readonly IErrorHandler _errorHandler;

        public PostController(IPostManager postManager, IMapper mapper, IErrorHandler errorHandler)
        {
            _postManager = postManager;
            _mapper = mapper;
            _errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var postDtos = await _postManager.GetAllAsync();
                var response = _mapper.Map<List<PostResponseModel>>(postDtos);

                return Ok(response);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var postDto = await _postManager.GetByIdAsync(id);

                if (postDto == null)
                    throw new CustomException("Post bulunamadı.", 404);

                var response = _mapper.Map<PostResponseModel>(postDto);
                return Ok(response);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestModel request)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var postDto = _mapper.Map<PostDto>(request);
                await _postManager.CreateAsync(postDto);

                return CreatedAtAction(nameof(GetById), new { id = postDto.Id }, new { Message = "Post başarıyla eklendi." });
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostRequestModel request)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                if (id != request.Id)
                    throw new CustomException("ID uyuşmazlığı.", 400);

                var postDto = _mapper.Map<PostDto>(request);
                await _postManager.UpdateAsync(postDto);

                return Ok(new { Message = "Post başarıyla güncellendi." });
            });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var message = await _postManager.HardDeleteAsync(id);
                return Ok(new { Message = message });
            });
        }
    }
}
