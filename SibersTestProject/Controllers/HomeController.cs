using Microsoft.AspNet.Identity;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServicesHost servicesHost)
            : base(servicesHost) {
        }

        [Authorize]
        public ActionResult Index()
        {
            var users = UserManager.Users.ToList();
            var roles = UserManager.GetRoles(users[0].Id).ToList();
            var viewUsers = new List<UserModel>();
            foreach (var user in users)
            {
                viewUsers.Add(new UserModel()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Roles = UserManager.GetRoles(user.Id).ToList()
                });
            }
            return View(viewUsers);
        }
    }
}