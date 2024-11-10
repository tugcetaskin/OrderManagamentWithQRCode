using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ProgressBarController : Controller
    {
        public IActionResult InstantStatus()
        {
            return View();
        }
    }
}
