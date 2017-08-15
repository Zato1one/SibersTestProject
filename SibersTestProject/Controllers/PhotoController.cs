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
            try
            {
                if (ModelState.IsValid)
                {
                    photo.Image = ServicesHost.GetService<IPhotoService>().FileBaseToImage(file);
                    photo.UserId = User.Identity.GetUserId();
                    ServicesHost.GetService<IPhotoService>().UploadPhoto(photo);
                    ViewBag.StateUpload = "Success upload";
                }
                return View();
            }
            catch (NullReferenceException)
            {
                ViewBag.StateUpload = "ImageNotSelected";
                return View();
            }
            catch (ExteptionTypeNotImage)
            {
                ViewBag.StateUpload = "FileTypeIsNotImage";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.StateUpload = e.Message;
                return View();
            }
        }
    }
}