using AutoMapper;
using SibersTestProject.Common.Model;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL.Entities;
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
using AutoMapper.QueryableExtensions;

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
            UnitOfWork.GetRepository<Image>().Delete(modelId);
            UnitOfWork.SaveChanges();
        }
        public PhotoModel GetById(Guid id)
        {
            var photoModel = UnitOfWork.GetRepository<Photo>().SearchFor(a=>a.EntityId==id)
                .ProjectTo<PhotoModel>().FirstOrDefault();
            return photoModel;
        }
        public void SavePhoto(PhotoModel photoModel)
        {
            var dbPhoto = UnitOfWork.GetRepository<Photo>().GetById(photoModel.EntityId);

            if (dbPhoto == null)
            {
                dbPhoto = Mapper.Map<Photo>(photoModel);
                UnitOfWork.GetRepository<Photo>().Insert(dbPhoto);
            }
            else
            {
                Mapper.Map(photoModel, dbPhoto);
                UnitOfWork.GetRepository<Photo>().Update(dbPhoto);
            }

            UnitOfWork.SaveChanges();
        }
        public ICollection<PhotoModel> GetAllUserPhoto(Guid userId)
        {
            var photoModel = UnitOfWork.GetRepository<Photo>()
                 .SearchFor(a => a.User.Id == userId).ProjectTo<PhotoModel>().ToList();
            return photoModel;
        }
        public void Edit(PhotoModel photoModel)
        {
            var dbPhoto = UnitOfWork.GetRepository<Photo>().GetById(photoModel.EntityId);
            if (dbPhoto == null) throw new NullReferenceException();
            Mapper.Map(photoModel, dbPhoto);

            UnitOfWork.GetRepository<Photo>().Update(dbPhoto);
            UnitOfWork.SaveChanges();
        }
        public ICollection<PhotoModel>Pagination(int page, int pageSize, out int totalRecord, out int totalPage, Guid userId)
        {
            totalRecord = UnitOfWork.GetRepository<Photo>().SearchFor(a => a.UserId == userId).Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);

            var photoList = UnitOfWork.GetRepository<Photo>()
                .SearchFor(a => a.UserId == userId).OrderBy(c=>c.EntityId)
                .Skip(((page - 1) * pageSize)).Take(pageSize).ProjectTo<PhotoModel>().ToList();

            return photoList;
        }
        public IQueryable<PhotoModel> GetAllPhotoByUserId(Guid userId)
        {
            return UnitOfWork.GetRepository<Photo>()
                .SearchFor(a => a.UserId == userId).OrderBy(b=>b.EntityId).ProjectTo<PhotoModel>();
        }
    }
}
