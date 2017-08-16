using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SibersTestProject.Common.Enums;
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
                var dbUser = Mapper.Map<ProjectUser>(registerView);
                var identityResult = await UserManager.CreateAsync(dbUser, registerView.Password);                
                if (identityResult.Succeeded)
                {
                    await UserManager.AddToRoleAsync(dbUser.Id, RoleName.User);
                    await SignIn(dbUser);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in identityResult.Errors)
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
                    await SignIn(user);
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

        private async Task SignIn(ProjectUser dbUser)
        {
            var ident = await UserManager.CreateIdentityAsync(dbUser, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(ident);
        }

    }
}