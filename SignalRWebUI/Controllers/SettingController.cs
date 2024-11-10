using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.DTOs.IdentityDTOs;

namespace SignalRWebUI.Controllers
{
	public class SettingController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public SettingController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			UserSettingDTO user = new UserSettingDTO()
			{
				Name = value.Name,
				Surname = value.Surname,
				Email = value.Email,
				Username = value.UserName
			};
			return View(user);
		}

		[HttpGet]
		public async Task<IActionResult> Update()
		{
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserSettingDTO user = new UserSettingDTO()
            {
                Name = value.Name,
                Surname = value.Surname,
                Email = value.Email,
                Username = value.UserName
            };
            return View(user);
        }

		[HttpPost]
        public async Task<IActionResult> Update(UserSettingDTO user)
        {
			if(user.Password == user.ConfirmPassword)
			{
                var value = await _userManager.FindByNameAsync(User.Identity.Name);
				value.Name = user.Name;
				value.Surname = user.Surname;
                value.Email = user.Email;
				value.UserName = user.Username;
                value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, user.Password);
				var result = await _userManager.UpdateAsync(value);
				return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
