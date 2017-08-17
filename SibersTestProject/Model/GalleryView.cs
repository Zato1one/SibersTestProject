using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model
{
    public class GalleryView
    {
        public Guid galleryId { get; set; }
        public ICollection<PhotoView> Photos { get; set; }
    }
}