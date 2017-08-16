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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Save(GalleryModel model)
        {
            throw new NotImplementedException();
        }
        public void CreateGallery(GalleryModel galleryModel)
        {

        }
        public ICollection<GalleryModel> GetAllGalleryByUserId(Guid userId)
        {
            var dbGallery = UnitOfWork.GetRepository<Gallery>()
                 .SearchFor(a => a.User.Id == userId).ToList();

            return Mapper.Map<ICollection<Gallery>, ICollection<GalleryModel>>(dbGallery);
        }
        public void Create(GalleryModel galleryModel)
        {
            var dbGallery = Mapper.Map<Gallery>(galleryModel);
            UnitOfWork.GetRepository<Gallery>().Insert(dbGallery);
            UnitOfWork.SaveChanges();
        }
    }
}
