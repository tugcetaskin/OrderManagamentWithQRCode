using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.DTOs.IdentityDTOs;

namespace SignalRWebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManage;

		public LoginController(SignInManager<AppUser> signInManage)
		{
			_signInManage = signInManage;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDTO login)
		{
			var result = await _signInManage.PasswordSignInAsync(login.Username, login.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			}
			return View(login);
		}
	}
}
