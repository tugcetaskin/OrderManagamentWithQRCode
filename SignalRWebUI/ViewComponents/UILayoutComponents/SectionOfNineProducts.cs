using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.CategoryDTOs;
using SignalRWebUI.DTOs.ProductDTOs;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class SectionOfNineProducts : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SectionOfNineProducts(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Categories = "Kategori Bulunamadı";
            var client = _httpClientFactory.CreateClient();

            var result = await client.GetAsync("https://localhost:7214/api/Product/GetNineProduct");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWitCategoryDTO>>(jsonData);

                ViewBag.Categories = values.GroupBy(x => x.CategoryName).Select(group => group.Key).ToList();
                return View(values);
            }
            return View();
        }
    }
}
