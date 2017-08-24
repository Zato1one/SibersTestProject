using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SibersTestProject.Common.Extensions;
using AutoMapper;
using SibersTestProject.Model.Photo;
using ImageResizer;
using System.Drawing;

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
            var photoModelList = ServicesHost.GetService<IPhotoService>().GetAllUserPhoto(userId);
            var photoViewList = Mapper.Map<ICollection<PhotoModel>, ICollection<PhotoView>>(photoModelList);

            return View(photoViewList);
        }

        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(PhotoView photoView, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    photoView.Image = ServicesHost.GetService<IPhotoService>().FileBaseToImage(file);
                    photoView.UserId = User.Identity.GetUserId();
                    var photoModel = Mapper.Map<PhotoModel>(photoView);
                    ServicesHost.GetService<IPhotoService>().UploadPhoto(photoModel);
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
        public ActionResult Delete(Guid id)
        {
            ServicesHost.GetService<IPhotoService>().Delete(id);
            return RedirectToAction ("Index");
        }
        public ActionResult Edit(Guid id)
        {
            var photoModel = ServicesHost.GetService<IPhotoService>().GetById(id);
            var photoView = Mapper.Map<PhotoView>(photoModel);
            photoView.EntityId = id;
            return View(photoView);
        }
        [HttpPost]
        public ActionResult Edit(PhotoView photoView, HttpPostedFileBase file)
        {

            photoView.Image = ServicesHost.GetService<IPhotoService>().FileBaseToImage(file);          
            var photoModel = Mapper.Map<PhotoModel>(photoView);
            ServicesHost.GetService<IPhotoService>().Edit(photoModel);
            //var photoModel = ServicesHost.GetService<IPhotoService>().GetById(id);
            //var photoView = Mapper.Map<PhotoView>(photoModel);
            return RedirectToAction("Index");
        }

    }
}