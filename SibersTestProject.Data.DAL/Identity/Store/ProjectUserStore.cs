using Microsoft.AspNet.Identity.EntityFramework;
using SibersTestProject.Data.Contracts.Context;
using SibersTestProject.Data.DAL.Identity.Entities;
using System;

namespace SibersTestProject.Data.DAL.Identity.Store
{
    public class ProjectUserStore : UserStore<ProjectUser, ProjectRole, Guid, ProjectUserLogin, ProjectUserRole, ProjectUserClaim>
    {
        public ProjectUserStore(IProjectContext context) 
            : base(context.DbContext) {
        }
    }
}
