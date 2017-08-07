using SibersTestProject.Data.DAL.Entities.Base;
using System.Data.Entity.ModelConfiguration;

namespace SibersTestProject.Data.DAL.Mappings.Base
{
    public class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseEntityMap()
        {

        }
    }
}
