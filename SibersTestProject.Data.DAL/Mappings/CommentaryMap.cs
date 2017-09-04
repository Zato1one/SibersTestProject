using SibersTestProject.Data.DAL.Entities;
using SibersTestProject.Data.DAL.Mappings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.DAL.Mappings
{
    public class CommentaryMap : BaseEntityMap<Commentary>
    {
        public CommentaryMap() 
            : base()
        {
            this.ToTable("Commentaries");

            this.HasRequired(p => p.User)
                .WithMany(p => p.Commentaries)
                .HasForeignKey(p => p.UserId);
        }
    }
}
