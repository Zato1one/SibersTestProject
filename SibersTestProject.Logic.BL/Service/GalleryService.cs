using SibersTestProject.Logic.BL.Service.Base;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL.Entities;
using AutoMapper;

namespace SibersTestProject.Logic.BL.Service
{
    public class GalleryService : HostService<IGalleryService>, IGalleryService
    {
        public GalleryService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {
        }
        public void Delete(Guid modelId)
        {
            UnitOfWork.GetRepository<Gallery>().Delete(modelId);
            UnitOfWork.SaveChanges();
        }

        public void Delete(GalleryModel model)
        {
            throw new NotImplementedException();
        }

        public List<GalleryModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public GalleryModel GetById(Guid id)
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>().SearchFor(a => a.EntityId == id).First();
            return Mapper.Map<GalleryModel>(dbGallery);

        }

        public void Save(GalleryModel model)
        {
            var store = UnitOfWork.GetRepository<Gallery>().GetById(model.EntityId);

            if (store == null)
            {
                store = Mapper.Map<Gallery>(model);
                UnitOfWork.GetRepository<Gallery>().Insert(store);
            }
            else
            {
                Mapper.Map(model, store);
                UnitOfWork.GetRepository<Gallery>().Update(store);
            }

            UnitOfWork.SaveChanges();
        }
        public void CreateGallery(GalleryModel galleryModel)
        {

        }
        public ICollection<GalleryModelWithoutImage> GetAllGalleryByUserId(Guid userId)
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>()
                 .SearchFor(a => a.User.Id == userId).ToList();

            return Mapper.Map<ICollection<Gallery>, ICollection<GalleryModelWithoutImage>>(dbGallery);
        }
        public GalleryModel GetGalleryById(Guid galleryId)
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>().GetById(galleryId);

            return Mapper.Map<GalleryModel>(dbGallery);
        }
        public void Create(GalleryModelWithoutImage galleryModel)
        {
            var dbGallery = Mapper.Map<Gallery>(galleryModel);
            UnitOfWork.GetRepository<Gallery>().Insert(dbGallery);
            UnitOfWork.SaveChanges();
        }
        public void CreatePhoto(Guid idGallery, ICollection<Guid> idPhotos)
        {
            var gallery = UnitOfWork.GetRepository<Gallery>().GetById(idGallery);
            if (gallery == null) throw new NullReferenceException();
            var photos = new List<Photo>();
            foreach (var idPhoto in idPhotos)
            {
                var photo = UnitOfWork.GetRepository<Photo>().GetById(idPhoto);
                photos.Add(photo);
            }
            if (gallery.Photos == null) gallery.Photos = photos;
            else gallery.Photos = gallery.Photos.Concat(photos).ToList();
            UnitOfWork.GetRepository<Gallery>().Update(gallery);
        }
        public ICollection<GalleryModelWithoutImage> GetAllPublicGallery()
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>().SearchFor(a => a.IsPublic).ToList();

            return Mapper.Map<ICollection<Gallery>, ICollection<GalleryModelWithoutImage>>(dbGallery);
        }
    }
}
