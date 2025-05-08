using DtoLayer.Dtos.AuthDtos;
using DtoLayer.Dtos.NewsDtos;
using DtoLayer.Dtos.TagDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

[Area("User")]
[Route("User/Home")]
public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string tag)
    {
        var client = _httpClientFactory.CreateClient();
        HttpResponseMessage response;

        if (string.IsNullOrEmpty(tag))
        {
            // Arama yapılmamışsa bütün haberleri çek
            response = await client.GetAsync("https://localhost:7012/api/News");
        }
        else
        {
            // Arama yapılmışsa sadece ilgili tag'e sahip haberleri çek
            response = await client.GetAsync($"https://localhost:7012/api/News/ByTag?tag={tag}");
        }

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultNewsDto>>(jsonData);
            return View(values);
        }

        return View(new List<ResultNewsDto>());
    }

    


}
