using AutoMapper;
using SibersTestProject.Common.Model;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Data.DAL.Identity.Entities;
using SibersTestProject.Logic.BL.Service.Base;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.BL.Service
{
    public class PhotoService : HostService<IPhotoService>, IPhotoService
    {

        public PhotoService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {         
        }

        public void Delete(Guid modelId)
        {
            throw new NotImplementedException();
        }

        public void Delete(PhotoModel model)
        {
            throw new NotImplementedException();
        }

        public List<PhotoModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PhotoModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(PhotoModel model)
        {
            throw new NotImplementedException();
        }

        public void UploadPhoto(PhotoModel photoModel)
        {
            var dbPhoto = Mapper.Map<Photo>(photoModel);
            UnitOfWork.GetRepository<Photo>().Insert(dbPhoto);
            UnitOfWork.SaveChanges();
        }
        public ICollection<PhotoModel> GetAllUserPhoto(Guid userId)
        {
            var dbPhoto = UnitOfWork.GetRepository<Photo>()
                 .SearchFor(a => !a.IsArchive && a.User.Id == userId).ToList();

            return Mapper.Map<ICollection<Photo>, ICollection<PhotoModel>>(dbPhoto);
        }
    }
}
