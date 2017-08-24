using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Data.DAL.Mappings.Base;

namespace SibersTestProject.Data.DAL.Mappings
{
    public class PhotoMap : BaseEntityMap<Photo>
    {
        public PhotoMap()
            : base()
        {
            this.ToTable("Photos");

            this.HasRequired(entity => entity.User)
                .WithMany(studio => studio.Photos)
                .HasForeignKey(entity => entity.UserId);

        }
    }
}
