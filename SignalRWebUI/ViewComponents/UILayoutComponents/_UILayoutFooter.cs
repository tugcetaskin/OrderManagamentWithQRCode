using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.ContactDTOs;
using SignalRWebUI.DTOs.SocialMediaDTOs;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutFooter : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7214/api/Contact/GetLast");
			if(response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var json = JsonConvert.DeserializeObject<GetContactDTO>(content);

				ViewBag.Social = new List<ResultSocialMediaDTO>();
                var socialRes = await client.GetAsync("https://localhost:7214/api/SocialMedia");
				if(socialRes.IsSuccessStatusCode)
				{
					var socialContent = await socialRes.Content.ReadAsStringAsync();
					var jsonData = JsonConvert.DeserializeObject<List<ResultSocialMediaDTO>>(socialContent);
					ViewBag.Social = jsonData;
                }
                return View(json);
            }
			return View();
		}
	}
}
