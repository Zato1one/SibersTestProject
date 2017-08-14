using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.Contracts.Service
{
    public interface IPhotoService : ICrudService<PhotoModel>
    {
        ICollection<PhotoModel> GetAllUserPhoto(string userName);
    }
}
