using ImageResizer;
using Microsoft.AspNet.Identity;
using SibersTestProject.Common.Enums;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                    EntityId = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Roles = UserManager.GetRoles(user.Id).ToList()
                });
            }
            return View(viewUsers);
        }
        public ActionResult Image(string imageResolution, Guid id)
        {
            try
            {
                var photoResolution = (PhotoResolution)Enum.Parse(
                                              typeof(PhotoResolution), imageResolution, true);
                var imgByteArr = ServicesHost.GetService<IImageService>().GetImageById(id, photoResolution);
                if (id == null) throw new NullReferenceException();
                var mimeType = "image/jpeg";
                return new FileContentResult(imgByteArr, mimeType);
            }
            catch
            {
                return HttpNotFound();
            }
        }
    }
}