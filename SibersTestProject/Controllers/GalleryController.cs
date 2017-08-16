using SibersTestProject.Common.Extensions;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    [Authorize]
    public class GalleryController : BaseController
    {
        public GalleryController(IServicesHost servicesHost)
            : base(servicesHost) {
        }
        public ActionResult Index()
        {
            var userId = AuthenticationManager.User.Identity.GetUserId();
            var galleryList = ServicesHost.GetService<IGalleryService>().GetAllGalleryByUserId(userId);
            return View(galleryList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GalleryModel galleryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    galleryModel.UserId = User.Identity.GetUserId();
                    ServicesHost.GetService<IGalleryService>().Create(galleryModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(galleryModel);
                }
            }
            catch(Exception e)
            {
                ViewBag.StateCreate = e.Message;
                return View(galleryModel);
            }
        }
    }
}