using Application.Repositories.AiLogRepository;
using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Repositories.AiLogRepository
{
    public class OpenRouterAiRepository : ReadRepository<AiLog>, IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenRouterAiRepository(NewsAppDbContext context , HttpClient httpClient, IConfiguration configuration) : base(context)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetResponseAsync(string prompt, string sourceModel)
        {
            var apiKey = _configuration["OpenRouter:ApiKey"];
            var model = string.IsNullOrEmpty(sourceModel) ? _configuration["OpenRouter:Model"] : sourceModel;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "https://openrouter.ai/");
            _httpClient.DefaultRequestHeaders.Add("X-Title", "NewsApp");

            var requestBody = new
            {
                model = model,
                messages = new[]
                {
                new { role = "user", content = prompt }
            }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://openrouter.ai/api/v1/chat/completions", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            using var json = JsonDocument.Parse(responseString);

            return json.RootElement
                       .GetProperty("choices")[0]
                       .GetProperty("message")
                       .GetProperty("content")
                       .GetString();
        }
    }
    
}
