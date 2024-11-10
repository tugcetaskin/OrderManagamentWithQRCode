using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.BookingDTOs;
using SignalRWebUI.DTOs.MailDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> RezervationList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7214/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7214/api/Booking/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("RezervationList");
            }
            return RedirectToAction("RezervationList");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDTO bookingDto)
        {
            bookingDto.Description = "Rezervasyon Oluşturuldu.";
            bookingDto.Date = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(bookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7214/api/Booking/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("RezervationList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7214/api/Booking/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBookingDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBookingDTO bookingDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(bookingDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7214/api/Booking/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("RezervationList");
            }
            return View();
        }

        public async Task<IActionResult> Confirm(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7214/api/Booking/Confirm/{id}");
            var responseMessage = await client.GetAsync($"https://localhost:7214/api/Booking/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetBookingDTO>(jsonData);
                CreateMailDTO mail = new CreateMailDTO();
                mail.ReceiverName = value.Name;
                mail.ReceiverEmail = value.Email;
                mail.Subject = "Rezervasyon Onayı";
                mail.Body = $"Sayın {value.Name}\n{value.Date} tarihinde yaptırmış olduğunuz {value.PersonCount} kişilik rezervasyonunuz onaylanmıştır. İptali durumunda lütfen iletişime geçiniz. \nİyi günler dileriz. \n\nDIOVOR";
                
                MailController.Index(mail);
                return RedirectToAction("RezervationList");
            }
            return RedirectToAction("RezervationList");
        }

        public async Task<IActionResult> Cancel(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7214/api/Booking/Cancel/{id}");
            var responseMessage = await client.GetAsync($"https://localhost:7214/api/Booking/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetBookingDTO>(jsonData);
                CreateMailDTO mail = new CreateMailDTO();
                mail.ReceiverName = value.Name;
                mail.ReceiverEmail = value.Email;
                mail.Subject = "Rezervasyon İptali";
                mail.Body = $"Sayın {value.Name}\n{value.Date} tarihinde yaptırmış olduğunuz {value.PersonCount} kişilik rezervasyonunuz iptal edilmiştir. Başka bir zaman sizleri ağırlamak isteriz. \nİyi günler dileriz. \n\nDIOVOR";

                MailController.Index(mail);
                return RedirectToAction("RezervationList");
            }
            return RedirectToAction("RezervationList");
        }
    }
}
