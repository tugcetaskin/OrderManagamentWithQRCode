
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.FeatureDTOs;
using SignalRWebUI.DTOs.SliderDTOs;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSliderSection : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutSliderSection(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7214/api/Sliders/");

            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
