using SibersTestProject.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class PhotoModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public Guid User_Id { get; set; } 
        public virtual UserModel User { get; set; }
        public virtual ICollection<GalleryModel> Galleries { get; set; }
    }
}
