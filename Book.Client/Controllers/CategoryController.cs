using Book.Client.Dtos;

using Book.Service.Dtos.Categories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Book.Client.Controllers
{
    public class CategoryController : Controller
    {
        private readonly string Endpoint = "http://localhost:7139";
        [HttpGet]
            public async Task<IActionResult> Index()
            {
                HttpClient httpClient = new HttpClient();
                GetItems<CategoryGetInfoDto> getItems = new GetItems<CategoryGetInfoDto>();
                getItems.Items = new List<CategoryGetInfoDto>();

                var json = await httpClient.GetStringAsync("https://localhost:7139/api/Categories");

                getItems = JsonConvert.DeserializeObject<GetItems<CategoryGetInfoDto>>(json);

                return View(getItems.Items);
            }
      
    }
}
