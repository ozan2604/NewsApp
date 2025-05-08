using DtoLayer.Dtos.AiLogDtos;
using DtoLayer.Dtos.TagDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Route("Admin/AiLogs")]
    [Authorize(Roles = "Author")]
    public class AiLogsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AiLogsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            

        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7012/api/AiLogs");

            if (response.IsSuccessStatusCode)
            { 
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultAiLogDto>>(json);
                return View(data);
            }

            return View(new List<ResultAiLogDto>());
        }





        [HttpGet]
        [Route("Create")]

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateAiLogDto createAiLogDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAiLogDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7012/api/AiLogs", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AiLogs", new { area = "Admin" });
            }

            return View(createAiLogDto);
        }



        [Route("Delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7012/api/AiLogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AiLogs", new { area = "Admin" });
            }

            return View();
        }



        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7012/api/AiLogs/{id}");

            if (!response.IsSuccessStatusCode)
            {
                // Loglama yapılabilir
                return RedirectToAction("Index");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var aiLog = JsonConvert.DeserializeObject<UpdateAiLogDto>(jsonData);

            return View(aiLog);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, UpdateAiLogDto updateAiLogDto)
        {
            if (id != updateAiLogDto.Id)
            {
                return BadRequest("ID uyuşmuyor.");
            }

            updateAiLogDto.UpdatedTime = DateTime.UtcNow;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAiLogDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7012/api/AiLogs/", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AiLogs", new { area = "Admin" });
            }

            // Hata durumunda formu tekrar göster
            ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");
            return View(updateAiLogDto);
        }
    }
}
