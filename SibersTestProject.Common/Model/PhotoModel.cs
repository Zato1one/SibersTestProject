﻿using SibersTestProject.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class PhotoModel : PhotoModelWithoutImage
    {
        public byte[] Image { get; set; }
    }
}
