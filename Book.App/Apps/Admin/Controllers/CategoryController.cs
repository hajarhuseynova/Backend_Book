using Book.Service.Dtos.Categories;
using Book.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.App.Admin.Controllers
{
   

        [ApiController]
        [Route("api/admin/[controller]")]
        [ApiExplorerSettings(GroupName = "admin_v1")]
        public class CategoriesController : ControllerBase
        {
            private readonly ICategoryService _categoryService;

            public CategoriesController(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {

                return StatusCode(200, await _categoryService.GetAllAsync());

            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var result = await _categoryService.GetAsync(id);
                return StatusCode(result.StatusCode, result);
            }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryPostDto dto)
        {
            var result = await _categoryService.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var result = await _categoryService.RemoveAsync(id);
                return StatusCode(result.StatusCode);

            }
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto dto)
            {
                var result = await _categoryService.UpdateAsync(id, dto);
                return StatusCode(result.StatusCode, result);

            }

        }
    
}