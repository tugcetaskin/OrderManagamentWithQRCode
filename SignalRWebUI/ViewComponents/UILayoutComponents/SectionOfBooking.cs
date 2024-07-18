using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class SectionOfBooking : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
