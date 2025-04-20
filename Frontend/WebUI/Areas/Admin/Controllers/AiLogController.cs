using DtoLayer.Dtos.AiLogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AiLog")]
    public class AiLogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AiLogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //builder.Services.AddHttpClient();	 program.cs ye eklemeyi unutma

        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7012/api/AiLogs");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAiLogDto>>(jsonData);

                return View(new List<ResultAiLogDto>());
            }

            return View();

            //serialize = metinden --> jsona (ekle , güncelle)
            //deserialize = jsondan --> metine (listele , ıdye göre getir)
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
            
            var simulatedResponse = $"Simüle edilen cevap: {createAiLogDto.Prompt} için cevap üretildi.";

            
            createAiLogDto.Response = simulatedResponse;
            createAiLogDto.IsSuccessful = true;
            createAiLogDto.ErrorMessage = string.Empty;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAiLogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7012/api/AiLogs", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AiLog", new { area = "Admin" });
            }

            
            return View();
        }



        [Route("Delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7012/api/AiLogs/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AiLog", new { area = "Admin" });
            }

            return View();
        }


        [Route("Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7012/api/AiLogs/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAiLogDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("Edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAiLogDto updateAiLogDto)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAiLogDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7012/api/AiLogs/", stringContent);


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AiLog", new { area = "Admin" });
            }
            return View();
        }
    }
}
