using Book.Service.Dtos.Books;
using Book.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.App.Admin.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    [ApiExplorerSettings(GroupName = "admin_v1")]
    public class BookController : ControllerBase
    {

        private readonly IBookService _BookService;

        public BookController(IBookService bookService)
        {
            _BookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return StatusCode(200, await _BookService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _BookService.GetAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BookPostDto dto)
        {
            var result = await _BookService.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _BookService.RemoveAsync(id);
            return StatusCode(result.StatusCode);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDto dto)
        {
            var result = await _BookService.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
