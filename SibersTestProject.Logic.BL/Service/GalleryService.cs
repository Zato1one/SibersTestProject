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
        public ICollection<GalleryModelWithoutImage> GetAllGalleryByUserId(Guid userId)
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>()
                 .SearchFor(a => a.User.Id == userId).ToList();

            return Mapper.Map<ICollection<Gallery>, ICollection<GalleryModelWithoutImage>>(dbGallery);
        }
        public GalleryModelWithoutImage GetGalleryById(Guid galleryId)
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>().GetById(galleryId);

            return Mapper.Map<GalleryModelWithoutImage>(dbGallery);
        }
        public GalleryModel GetGalleryByIdWithPhotos(Guid galleryId)
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>().GetById(galleryId);
            if (dbGallery.Photos == null) dbGallery.Photos = new List<Photo>();
            dbGallery.Photos = dbGallery.Photos.Where(a => !a.IsArchive).ToList();
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
            foreach (var idPhoto in idPhotos)
            {
                var photo = UnitOfWork.GetRepository<Photo>().GetById(idPhoto);
                gallery.Photos.Add(photo);
            }
            UnitOfWork.GetRepository<Gallery>().Update(gallery);
            UnitOfWork.SaveChanges();
        }
        public ICollection<GalleryModelWithoutImage> GetAllPublicGallery()
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>().SearchFor(a => a.IsPublic).ToList();
            return Mapper.Map<ICollection<Gallery>, ICollection<GalleryModelWithoutImage>>(dbGallery);
        }
        public void Edit(GalleryModelWithoutImage galleryModel)
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>().GetById(galleryModel.EntityId);
            Mapper.Map(galleryModel, dbGallery);

            UnitOfWork.GetRepository<Gallery>().Update(dbGallery);
            UnitOfWork.SaveChanges();
        }
        public void DeletePhoto(Guid idGallery, ICollection<Guid> idPhotos)
        {
            var gallery = UnitOfWork.GetRepository<Gallery>().GetById(idGallery);
            foreach (var idPhoto in idPhotos)
            {
                var photo = UnitOfWork.GetRepository<Photo>().GetById(idPhoto);
                gallery.Photos.Remove(photo);
            }
            UnitOfWork.GetRepository<Gallery>().Update(gallery);
            UnitOfWork.SaveChanges();
        }
    }
}
