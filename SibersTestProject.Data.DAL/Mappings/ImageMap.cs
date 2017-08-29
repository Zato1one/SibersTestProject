using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Data.DAL.Mappings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.DAL.Mappings
{
    public class ImageMap : BaseEntityMap<Image>
    {
        public ImageMap()
            : base()
        {
            this.ToTable("Images");

            this.HasKey(e => e.EntityId);
        }
    }
}
