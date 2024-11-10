using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.TestimonialDTOs;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    [AllowAnonymous]
    public class SectionOfTestimonials : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SectionOfTestimonials(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7214/api/Testimonial");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultTestimonialDTO>>(content);
                return View(jsonData);
            }
            return View();
        }
    }
}
