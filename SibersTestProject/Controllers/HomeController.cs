using Microsoft.AspNet.Identity;
using SibersTestProject.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
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
                    Role = UserManager.GetRoles(user.Id).ToList()
                });
            }
            return View(viewUsers);
        }
    }
}