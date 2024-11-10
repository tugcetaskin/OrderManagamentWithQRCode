using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.SliderDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> FeatureList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync("https://localhost:7214/api/Sliders");
            if(responseMes.IsSuccessStatusCode)
            {
                var jsonData = await responseMes.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.DeleteAsync($"https://localhost:7214/api/Sliders/{id}");
            if (responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderDTO featureDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(featureDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMes = await client.PostAsync("https://localhost:7214/api/Sliders/", content);
            if(responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync($"https://localhost:7214/api/Sliders/{id}");
            if(responseMes.IsSuccessStatusCode)
            {
                var jsonData = await responseMes.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSliderDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSliderDTO featureDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(featureDTO);
            StringContent content = new StringContent(jsonData, Encoding .UTF8, "application/json");
            var responseMes = await client.PutAsync("https://localhost:7214/api/Sliders/", content);
            if (responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View();
        }
    }
}
