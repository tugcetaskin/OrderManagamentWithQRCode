using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.CategoryDTOs;
using SignalRWebUI.DTOs.ProductDTOs;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class SectionOfMenu : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SectionOfMenu(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Categories = "Kategori Bulunamadı";
            var client = _httpClientFactory.CreateClient();
            var resultCategory = await client.GetAsync("https://localhost:7214/api/Category/");
            if (resultCategory.IsSuccessStatusCode)
            {
                var jsonCategory = await resultCategory.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonCategory);
                ViewBag.Categories = categories;
            }

            var result = await client.GetAsync("https://localhost:7214/api/Product/ProductListWithCategory");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWitCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
