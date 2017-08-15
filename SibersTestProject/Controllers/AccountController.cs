using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SibersTestProject.Common.Model;
using SibersTestProject.Data.DAL.Identity.Entities;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using SibersTestProject.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        public AccountController(IServicesHost servicesHost)
            : base(servicesHost) {
        }

        public ActionResult Register()
        {
            var registerView = new RegisterView();
            return View(registerView);
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterView registerView)
        {
            if (ModelState.IsValid)
            {
                var userModel = Mapper.Map<UserModel>(registerView);
                var resultRegistration = await ServicesHost.GetService<IAccountService>().RegisterUser(userModel);
                if (resultRegistration.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in resultRegistration.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(registerView);
        }

        public ActionResult Login(string returnUrl)
        {
            var login = new LoginView();
            ViewBag.returnUrl = returnUrl;
            return View(login);
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginView model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.Name, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Некорректное имя или пароль.");
                }
                else
                {
                    var ident = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    if (returnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(returnUrl);
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        private async Task SignIn(UserModel userModel)
        {

        }

    }
}