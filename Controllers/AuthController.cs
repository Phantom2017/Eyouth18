using Eyouth1.Models;
using Eyouth1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eyouth1.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var appuser=await userManager.FindByNameAsync(loginVM.UserName);
                if (appuser != null)
                {
                     var result=await signInManager.CheckPasswordSignInAsync(appuser, loginVM.Password,false);
                    if (result.Succeeded)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim("Age","25")
                        };
                        //await signInManager.SignInWithClaimsAsync(appuser,true,claims);
                        await signInManager.SignInAsync(appuser, true);
                        //User.IsInRole("User");
                        return RedirectToAction("Index", "Department");
                    }
                    else {
                        ModelState.AddModelError("", "Login data is wrong");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login data is wrong");
                }
            }
            return View(loginVM);
        }
        
        //Logout
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        //Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                var appUser = new AppUser
                {
                    UserName = vm.UserName,
                    Address = vm.Address
                };

                IdentityResult result=await userManager.CreateAsync(appUser,vm.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "User");
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Error in creation");
                }
            }
            return View(vm);
        }
        //ResetPassword
        //Forget password
    }
}
