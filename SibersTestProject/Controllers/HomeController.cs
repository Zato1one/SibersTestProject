using AutoMapper;
using ImageResizer;
using Microsoft.AspNet.Identity;
using SibersTestProject.Common.Enums;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using SibersTestProject.Model.Home;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IServicesHost servicesHost)
            : base(servicesHost) {
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Image(string imageResolution, Guid id)
        {
            try
            {
                var photoResolution = (PhotoResolution)Enum.Parse(
                                              typeof(PhotoResolution), imageResolution, true);

                var imgByteArr = ServicesHost.GetService<IImageService>().GetImageById(id, photoResolution);

                var mimeType = "image/jpeg";
                return new FileContentResult(imgByteArr, mimeType);
            }
            catch
            {
                return HttpNotFound();
            }
        }
    }
}