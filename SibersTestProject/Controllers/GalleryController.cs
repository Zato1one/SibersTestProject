using AutoMapper;
using SibersTestProject.Common.Extensions;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using SibersTestProject.Model;
using SibersTestProject.Model.Gallery;
using SibersTestProject.Model.Photo;
using System;
using System.Collections;
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
            var galleryModelList = ServicesHost.GetService<IGalleryService>().GetAllGalleryByUserId(userId);
            var galleryViewList = Mapper.Map<ICollection<GalleryModelWithoutImage>, ICollection<GalleryIndex>>(galleryModelList);
            return View(galleryViewList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GalleryCreate galleryView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    galleryView.UserId = User.Identity.GetUserId();
                    var galleryModel = Mapper.Map<GalleryModelWithoutImage>(galleryView);
                    ServicesHost.GetService<IGalleryService>().Create(galleryModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(galleryView);
                }
            }
            catch(Exception e)
            {
                ViewBag.StateCreate = e.Message;
                return View(galleryView);
            }
        }
        public ActionResult CreatePhoto(Guid id)
        {
            var galleryModel = ServicesHost.GetService<IGalleryService>().GetGalleryById(id);
            var galleryView = Mapper.Map<GalleryCreatePhoto>(galleryModel);
            var userId = User.Identity.GetUserId();
            var allGalleryPhotos = ServicesHost.GetService<IPhotoService>().GetAllUserPhoto(userId);
            galleryView.PhotoCheck = Mapper.Map<ICollection<PhotoModel>, ICollection<PhotoCheck>>(allGalleryPhotos).ToList();
            return View(galleryView);
        }
        [HttpPost]
        public ActionResult CreatePhoto(GalleryCreatePhoto galleryView)
        {
            if(galleryView==null)
            {
                throw new NullReferenceException();
            }
            var newPhotos = galleryView.PhotoCheck.Where(a => a.Check == true).Select(a=>a.EntityId).ToList();
            ServicesHost.GetService<IGalleryService>().CreatePhoto(galleryView.EntityId, newPhotos);
            return RedirectToAction("Index");
        }
        public ActionResult ViewGallery(Guid id)
        {
            var galleryModel = ServicesHost.GetService<IGalleryService>().GetGalleryById(id);
            var galleryView = Mapper.Map<GalleryView>(galleryModel);

            return View(galleryView);
        }
        public ActionResult Delete(Guid id)
        {
            ServicesHost.GetService<IGalleryService>().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult AllPublicGallery()
        {
            var galleryModelList = ServicesHost.GetService<IGalleryService>().GetAllPublicGallery();
            var galleryViewList = Mapper.Map<ICollection<GalleryModelWithoutImage>, ICollection<GalleryIndex>>(galleryModelList);
            return View(galleryViewList);
        }
    }
}