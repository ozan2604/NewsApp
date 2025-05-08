using Microsoft.AspNetCore.Authorization;
using DtoLayer.Dtos.NewsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistence.Context;
using System.Text;
using Application.Features.Mediatr.NewsQueries.GetAllNews;

namespace WebUI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Route("Admin/News")]
    [Authorize(Roles = "Admin,Author")]
    public class NewsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7012/api/News");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                // Artık doğrudan ResultNewsDto ile deserialize ediyoruz
                var dtoList = JsonConvert.DeserializeObject<List<ResultNewsDto>>(json);

                return View(dtoList);
            }

            return View(new List<ResultNewsDto>());
        }



        [HttpGet]
        [Route("Create")]
        [Authorize(Roles = "Author")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> Create(CreateNewsDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7012/api/News", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "News", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("Edit/{id}")]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7012/api/News/" + id);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateNewsDto>(json);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> Edit(UpdateNewsDto dto)
        {
            var client = _httpClientFactory.CreateClient();

            // 🔥 Zorunlu: Kullanıcıdan gelen PublishedAt LocalTime, bunu UTC'ye çeviriyoruz.
            dto.PublishedAt = DateTime.SpecifyKind(dto.PublishedAt, DateTimeKind.Local).ToUniversalTime();

            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7012/api/News", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "News", new { area = "Admin" });
            }

            
            var getResponse = await client.GetAsync($"https://localhost:7012/api/News/{dto.Id}");
            if (getResponse.IsSuccessStatusCode)
            {
                var getJson = await getResponse.Content.ReadAsStringAsync();
                var filledModel = JsonConvert.DeserializeObject<UpdateNewsDto>(getJson);

                ModelState.AddModelError("", "Haber güncellenemedi.");
                return View(filledModel);
            }

            ModelState.AddModelError("", "Haber güncellenemedi ve veriler tekrar çekilemedi.");
            return View(dto);
        }



        [HttpPost]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7012/api/News/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "News", new { area = "Admin" });
            }

            return RedirectToAction("Index", "News", new { area = "Admin" });
        }

        [HttpPost]
        [Route("AddTagToNews")]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> AddTagToNews(Guid newsId, Guid tagId)
        {
            var client = _httpClientFactory.CreateClient();

            var requestData = new
            {
                NewsId = newsId,
                TagId = tagId
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7012/api/News/AddTagToNews", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Edit", new { id = newsId });
            }

            TempData["ErrorMessage"] = "Etiket eklenemedi.";
            return RedirectToAction("Edit", new { id = newsId });
        }

        [HttpPost]
        [Route("RemoveTagFromNews")]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> RemoveTagFromNews(Guid newsId, Guid tagId)
        {
            var client = _httpClientFactory.CreateClient();

            var requestData = new
            {
                NewsId = newsId,
                TagId = tagId
            };

            var json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:7012/api/News/RemoveTagFromNews"),
                Content = content
            };

            var response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Edit", new { id = newsId });
            }

            TempData["ErrorMessage"] = "Etiket silinemedi.";
            return RedirectToAction("Edit", new { id = newsId });
        }
    }

}
