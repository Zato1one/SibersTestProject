﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class GalleryModel2 : GalleryModel
    {
        public ICollection<PhotoModel> Photos { get; set; }
    }
}
