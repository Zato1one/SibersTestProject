using ImageResizer;
using SibersTestProject.Common.Extensions;
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

namespace SibersTestProject.Logic.BL.Service
{
    public class ImageService : HostService<IImageService>, IImageService
    {
        public ImageService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {
        }

        public byte[] GetImageById(Guid id)
        {
            return UnitOfWork.GetRepository<Image>().GetById(id).SmallImage;
        }

        public byte[] FileBaseToArray(HttpPostedFileBase file)
        {
            byte[] image;
            if (!IsImageType(file)) throw new ExteptionTypeNotImage();
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                image = binaryReader.ReadBytes(file.ContentLength);
                return image;
            }
        }

        private bool IsImageType(HttpPostedFileBase file)
        {
            var ImageMinimumBytes = 512;
            var contentType = file.ContentType.ToLower();
            var contentLength = file.ContentLength;
            if (contentLength < ImageMinimumBytes) return false;
            if (contentType != "image/jpg" &&
                contentType != "image/jpeg" &&
                contentType != "image/pjpeg" &&
                contentType != "image/gif" &&
                contentType != "image/x-png" &&
                contentType != "image/png") return false;
            return true;
        }

        public void SaveImage(Guid id,byte[] arrayImage)
        {
            var dbImage = new Image() { EntityId = id };
            using (var memoryStream = new MemoryStream())
            {
                ImageBuilder.Current.Build(new ImageJob(arrayImage, memoryStream,
                    new Instructions()
                    {
                        Width = 100,
                        Height = 100,
                        Mode = FitMode.Carve
                    }));
                dbImage.SmallImage = memoryStream.ToArray();
                UnitOfWork.GetRepository<Image>().Insert(dbImage);
                UnitOfWork.SaveChanges();
            }
        }

    }
}
