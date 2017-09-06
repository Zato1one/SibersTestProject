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
            this.ToTable("Galleries");

            this.HasMany(a => a.Photos)
                .WithMany(b => b.Galleries)
                .Map(cs =>
                {
                    cs.ToTable("GalleryPhotos");
                });

            this.HasRequired(entity => entity.User)
                .WithMany(studio => studio.Galleries)
                .HasForeignKey(entity => entity.UserId);

        }
    }
}
