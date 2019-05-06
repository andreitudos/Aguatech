namespace Aguatech.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Aguatech.Web.Data.Entities;
    using Aguatech.Web.Helpers;
    using Aguatech.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;

        public AccountController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        //GET User Login
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        //POST User Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return this.Redirect(this.Request.Query["ReturnUrl"].First());
                    }

                    return this.RedirectToAction("Index", "Home");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Failed to login");
            return this.View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        // GET: /Account/Register 
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel view)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(view.Email);
                //Endereço Imagem do utilizador
                var path = string.Empty;
                if (user == null)
                {
                    user = this.ToUser(view);

                    var result = await this.userHelper.AddUserAsync(user, view.Password);
                    if (result != IdentityResult.Success)
                    {
                        this.ModelState.AddModelError(string.Empty, "The user couldn´t be created!");
                        return this.View(view);
                    }

                    var loginViewModel = new LoginViewModel
                    {
                        Password = view.Password,
                        RememberMe = false,
                        Username = view.UserName
                    };

                    var result2 = await this.userHelper.LoginAsync(loginViewModel);

                    if (result2.Succeeded)
                    {
                        return this.RedirectToAction("Index", "Home");
                    }

                    this.ModelState.AddModelError(string.Empty, "The user couldn´t login");
                    return this.View(view);

                }

                this.ModelState.AddModelError(string.Empty, "Thise user name already exists!");

            }
            return View(view);
        }

        private User ToUser(RegisterViewModel view)
        {
            return new User
            {
                FirstName = view.FirstName,
                LastName = view.LastName,
                UserName = view.UserName,
                Email = view.Email

            };
        }


        public async Task<IActionResult> ChangeUser()
        {
            var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
            var model = new ChangeUserViewModel();

            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeUser(ChangeUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    var response = await this.userHelper.UpdateUserAsync(user);
                    if (response.Succeeded)
                    {
                        this.ViewBag.UserMessager = "User Updated";
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User not found.");
                }
            }
            return this.View(model);
        }

        //GET: Change Password
        public IActionResult ChangePassword()
        {
            return this.View();
        }

        //POST: Change Password
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                if (user != null)
                {
                    var result = await this.userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return this.RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User no found.");
                }
            }

            return this.View(model);
        }
    }
}
