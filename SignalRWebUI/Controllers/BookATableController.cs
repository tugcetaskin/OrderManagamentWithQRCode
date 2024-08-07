using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.BookDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class BookATableController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Index(CreateBookDTO bookDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(bookDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7214/api/Booking/", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            return View();
        }
    }
}
