using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SibersTestProject.Logic.Contracts.Service.Base;
using System.Web;

namespace SibersTestProject.Logic.Contracts.Service
{
    public interface IImageService : IService
    {
        byte[] FileBaseToArray(HttpPostedFileBase file);
        void SaveImage(Guid id,byte[] arrayImage);
        byte[] GetImageById(Guid id);
    }
}
