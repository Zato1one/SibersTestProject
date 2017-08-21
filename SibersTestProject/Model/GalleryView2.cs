using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model
{
    public class GalleryView2
    {
        public Guid galleryId { get; set; }
        public ICollection<PhotoView2> Photos { get; set; }
    }
}