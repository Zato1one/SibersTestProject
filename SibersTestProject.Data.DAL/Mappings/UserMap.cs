using SibersTestProject.Data.DAL.Identity.Entities;
using SibersTestProject.Data.DAL.Mappings.Base;
using System.Data.Entity.ModelConfiguration;

namespace SibersTestProject.Data.DAL.Mappings
{
    public class UserMap : EntityTypeConfiguration<ProjectUser>
    {
        public UserMap()
            : base()
        {
            //this.HasMany(a => a.Photos)
            //    .WithRequired(b => b.User);

            //this.HasMany(a => a.Galleries)
            //    .WithRequired(b => b.User);
        }
    }
}
