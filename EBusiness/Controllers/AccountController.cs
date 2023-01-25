using EBusiness.Models;
using EBusiness.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EBusiness.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager= signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = await _userManager.FindByNameAsync(loginVM.Username);
            if(user==null)
            {
                ModelState.AddModelError("","Username or password is incorrect!");
                return View();
            };
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is incorrect!");
                return View();
            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            AppUser user = await _userManager.FindByNameAsync(registerVM.Username);
            if (user == null)
            {
                ModelState.AddModelError("Username", "Username is incorrect!");
                return View();
            };
            user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email is incorrect!");
                return View();
            };
            user = await _userManager.FindByNameAsync(registerVM.Fullname);
            if (user == null)
            {
                ModelState.AddModelError("Fullname", "Fullname is incorrect!");
                return View();
            };
            user = new AppUser
            {
                Email = registerVM.Email,
                Fullname = registerVM.Fullname,
                UserName = user.UserName,
            };
            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                ModelState.AddModelError("", error.Description);
                return View();
                }
            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
               await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index","Home");
        }
    }
}
