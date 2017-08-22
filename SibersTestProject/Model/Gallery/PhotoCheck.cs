using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Gallery
{
    public class PhotoCheck
    {
        public bool Check { get; set; }
        [UIHint("Image")]
        public byte[] Image { get; set; }
        [ScaffoldColumn(false)]
        public Guid EntityId { get; set; }
    }
}