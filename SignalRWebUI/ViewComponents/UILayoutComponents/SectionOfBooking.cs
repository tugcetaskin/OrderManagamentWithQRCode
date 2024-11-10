using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    [AllowAnonymous]
    public class SectionOfBooking : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
