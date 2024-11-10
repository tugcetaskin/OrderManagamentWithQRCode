using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    [AllowAnonymous]
    public class _UILayoutScript : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
