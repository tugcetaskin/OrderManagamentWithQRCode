using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.DiscountDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync("https://localhost:7214/api/Discount");
            if (responseMes.IsSuccessStatusCode)
            {
                var jsonData = await responseMes.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.DeleteAsync($"https://localhost:7214/api/Discount/{id}");
            if (responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountDTO discountDto)
        {
            discountDto.ImageUrl = "Deneme";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(discountDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMes = await client.PostAsync("https://localhost:7214/api/Discount/", content);
            if (responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync($"https://localhost:7214/api/Discount/{id}");
            if (responseMes.IsSuccessStatusCode)
            {
                var jsonData = await responseMes.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateDiscountDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDiscountDTO discountDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(discountDTO);
            StringContent content = new StringContent(jsonData, Encoding .UTF8, "application/json");
            var responseMes = await client.PutAsync("https://localhost:7214/api/Discount/", content);
            if (responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
