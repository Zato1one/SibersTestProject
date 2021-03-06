﻿using SibersTestProject.Model.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Gallery
{
    public class GalleryView
    {
        [ScaffoldColumn(false)]
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PhotoView> Photos { get; set; }
    }
}