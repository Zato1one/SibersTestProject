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
        ICollection<GalleryModelWithoutImage> GetAllGalleryByUserId(Guid userId);
        void Create(GalleryModelWithoutImage galleryModel);
        GalleryModel GetGalleryById(Guid galleryId);
        void CreatePhoto(Guid idGallery, ICollection<Guid> idPhotos);
        ICollection<GalleryModelWithoutImage> GetAllPublicGallery();
        void DeletePhoto(Guid idGallery, ICollection<Guid> idPhotos);
        void Edit(GalleryModel galleryModel);
    }
}
