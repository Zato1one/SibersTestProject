using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Photo
{
    public class PhotoView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }
    }
}