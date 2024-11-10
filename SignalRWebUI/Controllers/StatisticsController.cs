using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult InstantData()
        {
            return View();
        }
    }
}
