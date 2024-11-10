using DTOLayer.ContactDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.BookDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BookATableController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetMap()
        {
            var result = "Bulunamadı";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7214/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<GetContactDTO>>(jsonData);
                result = value.Take(1).Select(x => x.Location).FirstOrDefault();
            }
            return result;
        }

        [HttpGet]
		public async Task<IActionResult> Index()
		{
            ViewBag.Location = await GetMap();
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Index(CreateBookDTO bookDto)
        {
            ViewBag.Location = await GetMap();

            bookDto.Description = "Rezervasyon Oluşturuldu.";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(bookDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7214/api/Booking/", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View(bookDto);
            }
        }
    }
}
