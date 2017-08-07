using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Data.DAL.Mappings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.DAL.Mappings
{
    public class GalleryMap : BaseEntityMap<Gallery>
    {
        public GalleryMap()
            : base()
        {
            this.ToTable("Gallery");
            this.HasMany(a => a.Photos)
                .WithMany(b => b.Galleries);
            
        }
    }
}
