using AutoMapper;
using SibersTestProject.Common.Extensions;
using SibersTestProject.Common.Model;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Data.DAL.Identity.Entities;
using SibersTestProject.Logic.BL.Service.Base;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SibersTestProject.Logic.BL.Service
{
    public class PhotoService : HostService<IPhotoService>, IPhotoService
    {
        public PhotoService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {
        }

        public void Delete(Guid modelId)
        {
            UnitOfWork.GetRepository<Photo>().Delete(modelId);
            UnitOfWork.SaveChanges();
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
            var dbPhoto = UnitOfWork.GetRepository<Photo>().GetById(id);
            return Mapper.Map<PhotoModel>(dbPhoto);
        }

        public void Save(PhotoModel model)
        {
            var store = this.UnitOfWork.GetRepository<Photo>().GetById(model.EntityId);

            if (store == null)
            {
                store = AutoMapper.Mapper.Map<Photo>(model);
                this.UnitOfWork.GetRepository<Photo>().Insert(store);
            }
            else
            {
                AutoMapper.Mapper.Map(model, store);
                this.UnitOfWork.GetRepository<Photo>().Update(store);
            }

            this.UnitOfWork.SaveChanges();
        }

        public void SavePhoto(PhotoModel photoModel)
        {
            var dbPhoto = Mapper.Map<Photo>(photoModel);
            UnitOfWork.GetRepository<Photo>().Insert(dbPhoto);
            UnitOfWork.SaveChanges();
        }

        public ICollection<PhotoModel> GetAllUserPhoto(Guid userId)
        {
            var dbPhoto = UnitOfWork.GetRepository<Photo>()
                 .SearchFor(a => a.User.Id == userId).ToList();

            return Mapper.Map<ICollection<Photo>, ICollection<PhotoModel>>(dbPhoto);
        }
        public void Edit(PhotoModel model)
        {
            throw new NotImplementedException();
        }

    }
}
