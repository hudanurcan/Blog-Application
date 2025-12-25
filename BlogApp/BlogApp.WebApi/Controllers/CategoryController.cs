using AutoMapper;
using BlogApp.Application.DtoClasses;
using BlogApp.Application.Exceptions.Abstract;
using BlogApp.Application.Exceptions.Concrete;
using BlogApp.Application.ManagerInterfaces;
using BlogApp.ViewModels.RequestModels.Categories;
using BlogApp.ViewModels.ResponseModels.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    { 
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        private readonly IErrorHandler _errorHandler;

        public CategoryController(ICategoryManager categoryManager, IMapper mapper, IErrorHandler errorHandler)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
            _errorHandler = errorHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var categoryDtos = await _categoryManager.GetAllAsync();
                var response = _mapper.Map<List<CategoryResponseModel>>(categoryDtos);

                return Ok(response.Count == 0 ? new List<CategoryResponseModel>() : response);
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var postDto = await _categoryManager.GetByIdAsync(id);

                if (postDto == null)
                    throw new CustomException("Post bulunamadı.", 404);

                var response = _mapper.Map<CategoryResponseModel>(postDto);
                return Ok(response);
            });
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestModel request)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var categoryDto = _mapper.Map<CategoryDto>(request);
                await _categoryManager.CreateAsync(categoryDto);

                return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, new { Message = "Kategori başarıyla eklendi." });
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryRequestModel request)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                if (id != request.Id)
                    throw new CustomException("ID uyuşmazlığı.", 400);

                var categoryDto = _mapper.Map<CategoryDto>(request);
                await _categoryManager.UpdateAsync(categoryDto);

                return Ok(new { Message = "Kategori başarıyla güncellendi." });
            });
        }

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            return await _errorHandler.ExecuteWithErrorHandling(async () =>
            {
                var message = await _categoryManager.HardDeleteAsync(id);
                return Ok(new { Message = message });
            });
        }

    }
}
