using SibersTestProject.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model
{
    public class PhotoView
    {
        public Guid EntityId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public bool Check { get; set; }
    }
}