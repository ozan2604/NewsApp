using DtoLayer.Dtos.AuthDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Account")]
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

           
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Auth"); 
            }

            var response = await client.GetAsync($"https://localhost:7012/api/AppUsers/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var userInfo = JsonConvert.DeserializeObject<UserInfoDto>(jsonData);
                return View(userInfo); 
            }

            return View(new UserInfoDto()); 
        }


        [Route("Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7012/api/AppUsers/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateUserDto>(jsonData);
                return View(values); 
            }
            return View(new UpdateUserDto()); 
        }


        [Route("Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserDto updateUserDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateUserDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:7012/api/AppUsers", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Account", new { area = "User" });
            }

            
            ViewBag.Error = "Bilgiler güncellenemedi.";
            return View(updateUserDto);
        }

        [HttpPost]
        [Route("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount()
        {
            var client = _httpClientFactory.CreateClient();
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Auth", new { area = "User" });
            }

            var responseMessage = await client.DeleteAsync($"https://localhost:7012/api/AppUsers/{userId}");

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Hesabınız başarıyla silindi.";
                return RedirectToAction("Login", "Auth", new { area = "User" });
            }

            TempData["ErrorMessage"] = "Hesap silinemedi, lütfen tekrar deneyin.";
            return RedirectToAction("Index", "Account", new { area = "User" });
        }




    }
}
