﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutHeader : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
