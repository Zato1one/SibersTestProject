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
    }
}
