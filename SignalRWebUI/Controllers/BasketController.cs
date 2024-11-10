using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.BasketDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id, int tableId)
        {
			var client = _httpClientFactory.CreateClient();

			//if (id == 0 || id == null)
			//{
   //             var message = await client.GetAsync("https://localhost:7214/api/Basket/BasketIdByTable");
   //             if(message.IsSuccessStatusCode)
   //             {
   //                 var data = await message.Content.ReadAsStringAsync();
   //                 id = JsonConvert.DeserializeObject<int>(data);
   //             }
   //         }
		
			var url = $"https://localhost:7214/api/Basket?id={tableId}";

			var responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketByTableDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteProductInBasket(int id, int productId)
        {
            int table = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7214/api/Basket/BasketIdByProductAndTable?productId={productId}&tableID={table}");
            if (responseMessage.IsSuccessStatusCode)
            {
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<int>(jsonData);
				var delete = await client.DeleteAsync($"https://localhost:7214/api/Basket/{values}");
                if(delete.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { id = id });
                }
                return Json("Ürün Silinemedi!");
            }
			return Json("Ürün Bulunamadı!");
		}
    }
}
