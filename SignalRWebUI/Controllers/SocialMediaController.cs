using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.SocialMediaDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SocialMediaList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync("https://localhost:7214/api/SocialMedia");
            if(responseMes.IsSuccessStatusCode)
            {
                var jsonData = await responseMes.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.DeleteAsync($"https://localhost:7214/api/SocialMedia/{id}");
            if (responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDTO mediaDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(mediaDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMes = await client.PostAsync("https://localhost:7214/api/SocialMedia/", content);
            if (responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync($"https://localhost:7214/api/SocialMedia/{id}");
            if (responseMes.IsSuccessStatusCode)
            {
                var jsonData = await responseMes.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSocialMediaDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSocialMediaDTO mediaDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(mediaDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMes = await client.PutAsync("https://localhost:7214/api/SocialMedia/", content);
            if (responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
            return View();
        }
    }
}
