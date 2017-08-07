using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Data.DAL.Mappings.Base;

namespace SibersTestProject.Data.DAL.Mappings
{
    public class PhotoMap : BaseEntityMap<Photo>
    {
        public PhotoMap()
            : base()
        {
            this.ToTable("Photo");
        }
    }
}
