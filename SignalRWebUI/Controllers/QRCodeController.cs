using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRCoder;
using SignalRWebUI.DTOs.TableDTOs;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
    public class QRCodeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QRCodeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMes = await client.GetAsync("https://localhost:7214/api/TableForCustomers/GetTableList");
            if(responseMes.IsSuccessStatusCode)
            {
                var content = await responseMes.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<ResultTableDTO>>(content);
                ViewBag.List = data;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id)
        {
            string value = $"https://localhost:7152/Product/Menu/{id}";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return View();
        }
    }
}
