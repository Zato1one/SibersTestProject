using SibersTestProject.Common.Extensions;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    public class CommentaryController : BaseController
    {
        public CommentaryController(IServicesHost servicesHost)
            : base(servicesHost) {
        }

        public ActionResult CreateCommentary(Guid photoId)
        {
            var comment = new CommentaryModel()
            {
                PhotoId = photoId,
                UserId = AuthenticationManager.User.Identity.GetUserId()
            };
            return View(comment);
        }
        [HttpPost]
        public ActionResult CreateCommentary(CommentaryModel model)
        {
            ServicesHost.GetService<ICommentaryService>().CreateComment(model);
            return View();
        }
        public ActionResult ListCommentary(Guid photoId)
        {
            var photoList = ServicesHost.GetService<ICommentaryService>().GetAllByPhotoId(photoId);
            return View(photoList);
        }
        public ActionResult DeleteCommentary(Guid commentaryId)
        {
            ServicesHost.GetService<ICommentaryService>().DeleteCommentary(commentaryId);
            return RedirectToAction("Index", "Home");
            
        }
    }
}