using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.DTOs.CategoryDTOs;
using SignalRWebUI.DTOs.ProductDTOs;

namespace SignalRWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
