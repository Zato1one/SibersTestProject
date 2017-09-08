using SibersTestProject.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class GalleryModelWithUserName : GalleryModelWithoutImage
    {
        public string UserName { get; set; }

    }
}
