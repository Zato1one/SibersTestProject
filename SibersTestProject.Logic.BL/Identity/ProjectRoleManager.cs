using Microsoft.AspNet.Identity;
using SibersTestProject.Data.DAL.Identity.Entities;
using System;

namespace SibersTestProject.Logic.BL.Identity
{
    public class ProjectRoleManager : RoleManager<ProjectRole, Guid>
    {
        public ProjectRoleManager(IRoleStore<ProjectRole, Guid> roleStore)
            : base(roleStore) {
        }
    }
}
