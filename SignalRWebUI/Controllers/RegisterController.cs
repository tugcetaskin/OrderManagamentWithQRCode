using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.DTOs.IdentityDTOs;

namespace SignalRWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDTO register)
        {
            var appUser = new AppUser()
            {
                Name = register.Name,
                Email = register.Email,
                Surname = register.Surname,
                UserName = register.Username
            };
            var result = await _userManager.CreateAsync(appUser, register.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(register);
        }
    }
}
