using SibersTestProject.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Photo
{
    public class PhotoView : BaseView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }
    }
}