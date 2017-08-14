using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class PhotoController : BaseController
    {
        public PhotoController(IServicesHost servicesHost)
            : base(servicesHost) {
        }
        // GET: Photo
        public ActionResult Index()
        {
            var userName = AuthenticationManager.User.Identity.Name;
            var photoList = ServicesHost.GetService<IPhotoService>().GetAllUserPhoto(userName);
            return View(photoList);
        }
        public ActionResult Upload()
        {
            return View();
        }
    }
}