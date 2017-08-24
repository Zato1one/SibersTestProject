using SibersTestProject.Data.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.DAL.Entities
{
    public class Image : BaseEntity
    {
        public byte[] SmallImage { get; set; }
        public byte[] MediumImage { get; set; }
        public byte[] OriginalImage { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
