using DtoLayer.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    [Route("Admin/Category")]
    [Authorize(Roles = "Admin,Author")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7012/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            Guid? parentCategoryId = null;

            if (!string.IsNullOrEmpty(dto.ParentCategoryIdAsString))
            {
                if (Guid.TryParse(dto.ParentCategoryIdAsString, out Guid parsedId))
                {
                    parentCategoryId = parsedId;
                }
                else
                {
                    ModelState.AddModelError("ParentCategoryIdAsString", "Geçersiz GUID formatı");
                    return View(dto);
                }
            }

            var newCategory = new
            {
                Name = dto.Name,
                Image = dto.Image,
                ParentCategoryId = parentCategoryId
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7012/api/Categories", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View(dto);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7012/api/Categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(json);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(UpdateCategoryDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7012/api/Categories", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7012/api/Categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }

            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        
    }
}
