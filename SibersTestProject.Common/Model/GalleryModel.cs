﻿using SibersTestProject.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class GalleryModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<PhotoModel> Photos { get; set; }
        public virtual UserModel User { get; set; }
        public Guid User_Id { get; set; }
    }
}
