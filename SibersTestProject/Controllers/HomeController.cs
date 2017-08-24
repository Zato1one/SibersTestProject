using ImageResizer;
using Microsoft.AspNet.Identity;
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
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Roles = UserManager.GetRoles(user.Id).ToList()
                });
            }
            return View(viewUsers);
        }
        public FileContentResult Image2(Guid id)
        {
            var imgByteArr = ServicesHost.GetService<IPhotoService>().GetImageById(id);
            if (id == null) throw new NullReferenceException();

            
            return new FileContentResult(imgByteArr, "image/jpeg");
        }
        public FileContentResult Image(Guid id)
        {

                var imgByteArr = ServicesHost.GetService<IPhotoService>().GetImageById(id);
                if (id == null) throw new NullReferenceException();
            var inputStream = new MemoryStream(imgByteArr);

            var memoryStream = new MemoryStream();
            ImageBuilder.Current.Build(new ImageJob(inputStream, memoryStream,
                new Instructions()
                {
                    Width = 100,
                    Height = 100,
                    Mode = FitMode.Carve
                }));
            return new FileContentResult(memoryStream.ToArray(), "image/jpeg");

        }
    }
}