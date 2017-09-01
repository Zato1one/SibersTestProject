using ImageResizer;
using SibersTestProject.Common.Enums;
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
        private object lockObject = new object();

        public ImageService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {
        }

        public byte[] GetImageById(Guid id, PhotoResolution imageResolution)
        {
            lock (lockObject)
            {
                switch (imageResolution)
                {
                    case PhotoResolution.Small:
                        return UnitOfWork.GetRepository<Image>().SearchFor(a => a.EntityId == id).Select(c => c.SmallImage).FirstOrDefault();
                    case PhotoResolution.Medium:
                        return UnitOfWork.GetRepository<Image>().SearchFor(a => a.EntityId == id).Select(c => c.MediumImage).FirstOrDefault();
                    case PhotoResolution.Original:
                        return UnitOfWork.GetRepository<Image>().SearchFor(a => a.EntityId == id).Select(c => c.OriginalImage).FirstOrDefault();
                    default:
                        return null;
                }
            }
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
            dbImage = SaveImageLogic(dbImage, arrayImage);
            UnitOfWork.GetRepository<Image>().Insert(dbImage);
            UnitOfWork.SaveChanges();
        }

        public void DeleteImage(Guid id)
        {
            UnitOfWork.GetRepository<Image>().Delete(id);
            UnitOfWork.SaveChanges();
        }

        private Image SaveImageLogic(Image image, byte[] arrayImage)
        {
            var smallImageInstructions = new Instructions()
            {
                Width = 100,
                Height = 100,
                Mode = FitMode.Carve,
                Format = "jpg"
            };
            var mediumImageInstructions = new Instructions()
            {
                Width = 600,
                Height = 600,
                Mode = FitMode.Max,
                Format = "jpg"
            };
            using (var memoryStreamSmallImage = new MemoryStream())
            using (var memoryStreamMediumImage = new MemoryStream())
            { 
                ImageBuilder.Current.Build(new ImageJob(arrayImage, memoryStreamSmallImage, smallImageInstructions));
                image.SmallImage = memoryStreamSmallImage.ToArray();
                ImageBuilder.Current.Build(new ImageJob(arrayImage, memoryStreamMediumImage, mediumImageInstructions));
                image.MediumImage = memoryStreamMediumImage.ToArray();
            }
            image.OriginalImage = arrayImage;
            return image;
        }

        public void EditImage(Guid id, HttpPostedFileBase file)
        {
            var arrayImage = FileBaseToArray(file);
            var image = UnitOfWork.GetRepository<Image>().GetById(id);
            if (image == null) throw new NullReferenceException();
            var dbImage = SaveImageLogic(image, arrayImage);
            UnitOfWork.GetRepository<Image>().Update(dbImage);
            UnitOfWork.SaveChanges();
        }

    }
}
