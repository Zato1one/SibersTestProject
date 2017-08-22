using SibersTestProject.Model.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Model.Gallery
{
    public class GalleryCreatePhoto
    {
        [ScaffoldColumn(false)]
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<PhotoCheck> PhotoCheck { get; set; }
    }
}