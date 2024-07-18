using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.TestimonialDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync("https://localhost:7214/api/Testimonial");
            if(responseMes.IsSuccessStatusCode)
            {
                var jsonData = await responseMes.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.DeleteAsync($"https://localhost:7214/api/Testimonial/{id}");
            if(responseMes.IsSuccessStatusCode)
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
        public async Task<IActionResult> Create(CreateTestimonialDTO testimonialDTO)
        {
            testimonialDTO.ImageUrl = "Deneme";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(testimonialDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMes = await client.PostAsync("https://localhost:7214/api/Testimonial/", content);
            if(responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync($"https://localhost:7214/api/Testimonial/{id}");
            if(responseMes.IsSuccessStatusCode)
            {
                var jsonData = await responseMes.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateTestimonialDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialDTO testimonialDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(testimonialDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMes = await client.PutAsync("https://localhost:7214/api/Testimonial/", content);
            if(responseMes.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
