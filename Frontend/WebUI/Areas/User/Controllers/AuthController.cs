using Application.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using DtoLayer.Dtos.AuthDtos;

namespace WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/Auth")]
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        [Route("Login")]
        public IActionResult Login() => View();

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            var client = _httpClientFactory.CreateClient();

            var loginData = new
            {
                Username = Username,
                Password = Password
            };

            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7012/api/Login", content);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Giriş başarısız.";
                return View();
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            var tokenResult = JsonConvert.DeserializeObject<TokenResponseDto>(responseJson);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(tokenResult.Token);

            var claims = token.Claims.ToList();

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = tokenResult.ExpireDate
            });

            
            var roleClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            return roleClaim switch
            {
                "Admin" => RedirectToAction("Index", "News", new { area = "Admin" }),
                "Author" => RedirectToAction("Index", "News", new { area = "Admin" }),
                "Member" => RedirectToAction("Index", "Home", new { area = "User" }),
                _ => RedirectToAction("Login", "Auth", new { area = "User" }) 
            };
        }


        [HttpGet]
        [Route("Register")]

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(registerDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7012/api/Register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Auth", new { area = "User" });
            }

            ViewBag.ErrorMessage = await response.Content.ReadAsStringAsync();
            return View();
        }
    }
}

