using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class SectionOfAbout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
