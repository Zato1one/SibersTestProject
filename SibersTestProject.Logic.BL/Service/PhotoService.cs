using AutoMapper;
using SibersTestProject.Common.Model;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL.Entities;
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

        public void UploadPhoto(string userName, PhotoModel photoModel)
        {
            var dbPhoto = new Photo()
            {
                Image = photoModel.Image,
                Name = photoModel.Name,
                Description = photoModel.Description
            };
            UnitOfWork.GetRepository<Photo>().Insert(dbPhoto);
            UnitOfWork.SaveChanges();
        }
        public ICollection<PhotoModel> GetAllUserPhoto(string userName)
        {
            var dbPhoto = UnitOfWork.GetRepository<Photo>()
                .SearchFor(a => !a.IsArchive && a.User.UserName == userName).ToList();

            return Mapper.Map<ICollection<Photo>, ICollection<PhotoModel>>(dbPhoto);
        }
        public void UploadPhoto(PhotoModel photo)
        {

        }
        public string HelloWorld(string Hello)
        {
            return Hello + "World";
        }
    }
}
