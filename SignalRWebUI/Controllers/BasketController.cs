using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.BasketDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7214/api/Basket?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketByTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteProductInBasket(int id)
        {
            int table = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7214/api/Basket/BasketIdByProductAndTable?productId={id}&tableID={table}");
            if (responseMessage.IsSuccessStatusCode)
            {
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<int>(jsonData);
				var delete = await client.DeleteAsync($"https://localhost:7214/api/Basket/{values}");
                if(delete.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return Json("Ürün Silinemedi!");
            }
			return Json("Ürün Bulunamadı!");
		}
    }
}
