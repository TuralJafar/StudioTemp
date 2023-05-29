using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudioTemp.Migrations;
using StudioTemp.Models;
using StudioTemp.ViewModels.Account;

namespace StudioTemp.Areas.AdminPanel.Controllers
{
    [Area("adminpanel")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {  

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Register(RegisterVM registerVM)
        {
            if(registerVM== null) return View();
            AppUser appUser = new AppUser()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                Surname = registerVM.Surname,
                UserName=registerVM.Username
            };
            IdentityResult result=await _userManager.CreateAsync(appUser,registerVM.Password);
            if(!result.Succeeded) 
            {
                foreach(IdentityError error in result.Errors)
                {
                   ModelState.AddModelError(string.Empty, error.Description);
                }return View();
            }
            await _signInManager.SignInAsync(appUser, false);
            return RedirectToAction("Index","Home",new {area=""});
        }
       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginVM loginVM)
        {
            if(loginVM==null) return View();
            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.Email);
            if(appUser==null)
            {
                appUser = await _userManager.FindByNameAsync(loginVM.Email);
                if(appUser!=null) { ModelState.AddModelError(string.Empty, "Not Account"); }
            }
            await _signInManager.SignInAsync(appUser,false,"method");
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
