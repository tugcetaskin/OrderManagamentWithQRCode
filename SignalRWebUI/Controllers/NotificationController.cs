using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.NotificationDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7214/api/Notifcations");
            if(responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultNotificationDTO>>(content);
                return View(jsonData);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification()
        { 
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDTO noti)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(noti);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7214/api/Notifcations", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(noti);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7214/api/Notifcations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<GetNotificationDTO>(content);
                return View(jsonData);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(UpdateNotificationDTO noti)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(noti);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7214/api/Notifcations/", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(noti);
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7214/api/Notifcations/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
