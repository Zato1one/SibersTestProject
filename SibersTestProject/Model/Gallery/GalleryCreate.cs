using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Gallery
{
    public class GalleryCreate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }
        public bool IsPublic { get; set; }
    }
}