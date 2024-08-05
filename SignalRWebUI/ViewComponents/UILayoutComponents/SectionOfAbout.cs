using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.AboutDTOs;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class SectionOfAbout : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SectionOfAbout(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7214/api/About/GetLastAbout");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetAboutDTO>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
