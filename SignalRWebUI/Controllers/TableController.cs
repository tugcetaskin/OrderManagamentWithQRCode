using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.TableDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class TableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7214/api/TableForCustomers/GetTableList");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<ResultTableDTO>>(content);
                return View(jsonData);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTable()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable(CreateTableDTO table)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(table);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7214/api/TableForCustomers/", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(table);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7214/api/TableForCustomers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UpdateTableDTO>(content);
                return View(jsonData);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTable(UpdateTableDTO table)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(table);
            StringContent content = new StringContent(jsonData, Encoding .UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7214/api/TableForCustomers", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(table);
        }

        public async Task<IActionResult> DeleteTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7214/api/TableForCustomers/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
