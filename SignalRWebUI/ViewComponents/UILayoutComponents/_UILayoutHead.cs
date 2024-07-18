using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutHead : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
