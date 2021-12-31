using Jcf.Dominio.Entidades;
using Jcf.Web.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var resultado = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);

                if(resultado != null && resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("message", "Credenciais Inválidas!");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult AccessDenied() { return View(); }

        public async Task<string> CreateAdmin(string username)
        {
            AppUser appUser = new AppUser();    

            appUser.UserName = username;
            appUser.Email = "admin@jcf.com.br";
            appUser.Nome = "Administrador";
            appUser.Cpf = username;
            appUser.EmailConfirmed = true;
            
            var result = await userManager.CreateAsync(appUser, "S123456@senha");
            if( result.Succeeded)
            {
                return "Admin Criado: " + username;
            }
            
            return "Usuário não criado";
        }
    }
}
