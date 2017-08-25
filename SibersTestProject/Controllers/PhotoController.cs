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
using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Common.Enums;

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
                    var arrayImage = ServicesHost.GetService<IImageService>().FileBaseToArray(file);                  
                    photoView.UserId = User.Identity.GetUserId();
                    var photoModel = Mapper.Map<PhotoModel>(photoView);
                    ServicesHost.GetService<IPhotoService>().SavePhoto(photoModel);
                    ServicesHost.GetService<IImageService>().SaveImage(photoModel.EntityId,arrayImage);
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
        public ActionResult Open(Guid id)
        {
            var photo = ServicesHost.GetService<IPhotoService>().GetById(id);
            return View(photo);
        }
        public ActionResult Save(Guid id)
        {
            string contentType = "Image/jpeg";
            byte[] image = ServicesHost.GetService<IImageService>().GetImageById(id, PhotoResolution.Original);
            if (image == null)
            {
                return HttpNotFound();
            }
            return File(image, contentType, Guid.NewGuid().ToString() + ".jpg");
    }
        public ActionResult Edit(Guid id)
        {
            var photo = ServicesHost.GetService<IPhotoService>().GetById(id);
            var photoView = Mapper.Map<PhotoView>(photo);
            return View(photoView);
        }
        [HttpPost]
        public ActionResult Edit(PhotoView photoView, HttpPostedFileBase file)
        {
            var photoModel = Mapper.Map<PhotoModel>(photoView);
            ServicesHost.GetService<IPhotoService>().Edit(photoModel);
            if(file!=null)
            {
                //change image 
                ServicesHost.GetService<IImageService>().EditImage(photoModel.EntityId, file);
            }
            return RedirectToAction("Index");
        }
    }
}