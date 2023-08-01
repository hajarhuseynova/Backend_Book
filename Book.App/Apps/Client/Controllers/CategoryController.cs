using Book.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.App.Client.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        [ApiExplorerSettings(GroupName = "client_v1")]
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

        
    }
}
