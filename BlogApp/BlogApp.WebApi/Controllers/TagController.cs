using AutoMapper;
using BlogApp.Application.DtoClasses;
using BlogApp.Application.Exceptions.Abstract;
using BlogApp.Application.Exceptions.Concrete;
using BlogApp.Application.ManagerInterfaces;
using BlogApp.ViewModels.RequestModels.Tags;
using BlogApp.ViewModels.ResponseModels.Tags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagManager _tagManager;
        private readonly IMapper _mapper;
        private readonly IErrorHandler _errorHandler;

        public TagController(ITagManager tagManager, IMapper mapper, IErrorHandler errorHandler)
        {
            _tagManager = tagManager;
            _mapper = mapper;
            _errorHandler = errorHandler;
        }

        // 1. Listeleme
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var tagDtos = await _tagManager.GetAllAsync();
                var response = _mapper.Map<List<TagResponseModel>>(tagDtos);
                return Ok(response);
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagRequestModel request)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var tagDto = _mapper.Map<TagDto>(request);
                await _tagManager.CreateAsync(tagDto);

                return StatusCode(210, new { Message = "Etiket başarıyla eklendi." });
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var message = await _tagManager.HardDeleteAsync(id);
                return Ok(new { Message = message });
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTagRequestModel request)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                if (id != request.Id)
                    throw new CustomException("ID uyuşmazlığı.", 400);

                var tagDto = _mapper.Map<TagDto>(request);
                await _tagManager.UpdateAsync(tagDto);

                return Ok(new { Message = "Etiket başarıyla güncellendi." });
            });
        }
    }
}
