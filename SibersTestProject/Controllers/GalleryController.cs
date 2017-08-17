using AutoMapper;
using SibersTestProject.Common.Extensions;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using SibersTestProject.Model;
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
        public ActionResult CreatePhoto(Guid id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var userId = AuthenticationManager.User.Identity.GetUserId();
            var photoList = ServicesHost.GetService<IPhotoService>().GetAllUserPhoto(userId);
            var galleryView = new GalleryView()
            {
                galleryId = id,
                Photos = Mapper.Map<ICollection<PhotoModel>, ICollection<PhotoView>>(photoList)
            };
            return View(galleryView);
        }
        [HttpPost]
        public ActionResult CreatePhoto(GalleryView photoList)
        {
            //var photoViewList = photoList.Where(a => a.Check == true).ToList();
            //var photoModel = Mapper.Map<ICollection<PhotoView>, ICollection<PhotoModel>>(photoViewList);
            //var galleryModel = ServicesHost.GetService<IGalleryService>().GetById(PhotoView.Gallery);
            //galleryModel.Photos = photoModel;
            //ServicesHost.GetService<IGalleryService>().Save(galleryModel);
            //RedirectToAction("ViewGallery", galleryModel);
            return View();
        }
        public ActionResult ViewGallery(GalleryModel galleryModel)
        {
            if(galleryModel==null)
            {
                return HttpNotFound();
            }

            return View(galleryModel);
        }
    }
}