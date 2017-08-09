using SibersTestProject.Common.Model;
using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.BL.Service
{
    public class PhotoPresentationService : IPhotoPresentationService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public PhotoPresentationService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        public ICollection<PhotoModel> GetAllPhoto(string userName)
        {
            var photoList = new List<PhotoModel>();
            var dbPhoto = UnitOfWork.GetRepository<Photo>()
                .SearchFor(a => !a.IsArchive && a.User.UserName==userName).ToList();
            foreach (var item in dbPhoto)//TO DO: AutoMaper
            {
                var photo = new PhotoModel()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image
                };
                photoList.Add(photo);
            }
            return photoList;
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
    }
}
