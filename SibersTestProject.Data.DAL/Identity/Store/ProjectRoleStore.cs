using Microsoft.AspNet.Identity.EntityFramework;
using SibersTestProject.Data.Contracts.Context;
using SibersTestProject.Data.DAL.Identity.Entities;
using System;

namespace SibersTestProject.Data.DAL.Identity.Store
{
    public class ProjectRoleStore : RoleStore<ProjectRole, Guid, ProjectUserRole>
    {
        public ProjectRoleStore(IProjectDbContext context)
            : base(context.DbContext) {
        }
    }
}
