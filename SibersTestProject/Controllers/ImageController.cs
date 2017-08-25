using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    public class ImageController : BaseController
    {
        public ImageController(IServicesHost servicesHost)
            : base(servicesHost) {
        }
        //public FileContentResult GetImageById(Guid id)
        //{

        //    var imgByteArr = ServicesHost.GetService<IImageService>().GetImageById(id);
        //    if (id == null) throw new NullReferenceException();


        //    return new FileContentResult(imgByteArr, "image/jpeg");
        //}
    }
}