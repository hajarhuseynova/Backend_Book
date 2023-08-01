using Book.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book.App.Client.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "client_v1")]
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
    }
    }
