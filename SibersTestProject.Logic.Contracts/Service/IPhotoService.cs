using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SibersTestProject.Logic.Contracts.Service
{
    public interface IPhotoService : IService
    {
        ICollection<PhotoModel> GetAllUserPhoto(Guid userId);
        void SavePhoto(PhotoModel photoModel);
        void Edit(PhotoModel photoModel);
        void Delete(Guid modelId);
        PhotoModel GetById(Guid id);
        ICollection<PhotoModel> Pagination(int page, int pageSize, out int totalRecord, out int totalPage, Guid userId);
    }
}
