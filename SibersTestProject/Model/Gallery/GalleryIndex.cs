using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Gallery
{
    public class GalleryIndex
    {
        [ScaffoldColumn(false)]
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}