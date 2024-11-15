﻿using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.BasketDTOs;
using SignalRWebUI.DTOs.CategoryDTOs;
using SignalRWebUI.DTOs.ProductDTOs;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [AllowAnonymous]
        public IActionResult Menu()
        {
            return View();
        }
        public async Task<IActionResult> MenuList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7214/api/Product/ProductListWithCategory");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWitCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7214/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                List<SelectListItem> category = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString(),
                                                 }).ToList();
                ViewBag.Category = category;
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO productDTO)
        {
            productDTO.ImageUrl = "Deneme";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(productDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7214/api/Product", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MenuList");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7214/api/Product/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MenuList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseForCategory = await client.GetAsync("https://localhost:7214/api/Category/");
            if (responseForCategory.IsSuccessStatusCode)
            {
                var jsonData = await responseForCategory.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                List<SelectListItem> category = (from x in values
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString(),
                                                 }).ToList();
                ViewBag.Category = category;
            }

            var responseMessage = await client.GetAsync($"https://localhost:7214/api/Product/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDTO productDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(productDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7214/api/Product/", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MenuList");
            }
            return View();
        }

        public async Task<TableForCustomer> AvailableTable()
        {
            var client = _httpClientFactory.CreateClient();
            var resTable = await client.GetAsync("https://localhost:7214/api/TableForCustomers/AvailableOnlineTable");
            if (resTable.IsSuccessStatusCode)
            {
                var json = await resTable.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<TableForCustomer>(json);

                data.Status = true;
                var jsonTable = JsonConvert.SerializeObject(data);
                StringContent tableContent = new StringContent(jsonTable, Encoding.UTF8, "application/json");
                var mess = await client.PutAsync("https://localhost:7214/api/TableForCustomers/", tableContent);
                return data;
            }
            return null;
        }
        public async Task<TableForCustomer> NewTable()
        {
			var client = _httpClientFactory.CreateClient();
			var resTable = await client.GetAsync("https://localhost:7214/api/TableForCustomers/NewTableNumber");
			if (resTable.IsSuccessStatusCode)
			{
				var json = await resTable.Content.ReadAsStringAsync();
				int tableId = Convert.ToInt32((string)json);
				TableForCustomer online = new TableForCustomer()
				{
					Id = tableId,
					Name = "Online",
					Status = true,
					TableFor = 4,
				};
                var jsonTable = JsonConvert.SerializeObject(online);
                var content = new StringContent(jsonTable, Encoding.UTF8, "application/json");
				var create = await client.PostAsync("https://localhost:7214/api/TableForCustomers/", content);
                if(create.IsSuccessStatusCode)
                {
                    return online;
                }
				throw new Exception("Yeni Masa Üretilemedi!");
			}
			throw new Exception("Yeni Masa Id Üretilemedi!");
		}
		[HttpPost]
		public async Task<IActionResult> AddToBasket(int id, int tableId)
		{
			var client = _httpClientFactory.CreateClient();

			if (tableId == 0 || tableId == null)
            {
                var available = await AvailableTable();
                if (available == null)
                {
					var table = await NewTable();
					tableId = table.Id;
				}
                else
                {
                    tableId = available.Id;
                }
			}
            CreateBasketDTO basket = new CreateBasketDTO()
            {
                ProductId = id,
                TableId = tableId,
            };
			
			var jsonData = JsonConvert.SerializeObject(basket);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMes = await client.PostAsync("https://localhost:7214/api/Basket/", content);
			if (responseMes.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Basket", new { tableId = tableId });
			}
			return Json(basket);
		}
	}
}
