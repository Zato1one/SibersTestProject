using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.Contracts.Service
{
    public interface IGalleryService : ICrudService<GalleryModel>
    {
        ICollection<GalleryModel> GetAllGalleryByUserId(Guid userId);
        void Create(GalleryModel galleryModel);
    }
}
