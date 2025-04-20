using Domain.Entities;
using DtoLayer.Dtos.TagDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence.Context;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Tag")]
    public class TagController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TagController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //builder.Services.AddHttpClient();	 program.cs ye eklemeyi unutma

        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var responseMessage = await  httpClient.GetAsync("https://localhost:7012/api/Tags");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTagDto>>(jsonData);

                return View(values);
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

        public async Task<IActionResult> Create(CreateTagDto createtagDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createtagDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7012/api/Tags", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Tag", new { area = "Admin" });
            }
            return View();
        }



        [Route("Delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7012/api/Tags/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Tag", new { area = "Admin" });
            }

            return View();
        }


        [Route("Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7012/api/Tags/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTagDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("Edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTagDto updateTagDto)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTagDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7012/api/Tags/", stringContent);


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Tag", new { area = "Admin" });
            }
            return View();
        }

    }
}
