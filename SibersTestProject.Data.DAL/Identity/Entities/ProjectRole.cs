using Microsoft.AspNet.Identity.EntityFramework;
using System;


namespace SibersTestProject.Data.DAL.Identity.Entities
{
    public class ProjectRole : IdentityRole<Guid, ProjectUserRole>
    {
        public ProjectRole()
        {
            Id = Guid.NewGuid();
        }

        public ProjectRole(string roleName)
            : this()
        {
            Name = roleName;
        }
    }
}
