using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;
using SibersTestProject.Common.Extensions;

namespace SibersTestProject.Controllers
{
    [Authorize]
    public class PhotoController : BaseController
    {
        public PhotoController(IServicesHost servicesHost)
            : base(servicesHost) {
        }
        // GET: Photo
        public ActionResult Index()
        {
            var userId = AuthenticationManager.User.Identity.GetUserId();
            var photoList = ServicesHost.GetService<IPhotoService>().GetAllUserPhoto(userId);
            return View(photoList);
        }
        public ActionResult Upload()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Upload([Bind(Include = "Name,Description")]PhotoModel photo, HttpPostedFileBase file)
        {
            //try
            //{
            if (file != null && file.ContentLength > 0 && ModelState.IsValid)
            {
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    photo.Image = binaryReader.ReadBytes(file.ContentLength);
                }
                photo.UserId = User.Identity.GetUserId(); 
                var userName = User.Identity.Name;
                ServicesHost.GetService<IPhotoService>().UploadPhoto(photo);
                ViewBag.StateUpload = "Success upload";
            }
            else
            {
                ViewBag.StateUpload = "file != null && file.ContentLength > 0 && ModelState.IsValid";
            }
            return View();
            //}
            //catch
            //{
            //    ViewBag.StateUpload = "Exception";
            //    return View();
            //}
        }
    }
}