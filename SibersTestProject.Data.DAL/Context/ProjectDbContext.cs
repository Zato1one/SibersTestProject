using Microsoft.AspNet.Identity.EntityFramework;
using SibersTestProject.Data.Contracts.Context;
using SibersTestProject.Data.DAL.Identity.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SibersTestProject.Data.DAL.Mappings;

namespace SibersTestProject.Data.DAL.Context
{
    public class ProjectDbContext : IdentityDbContext<ProjectUser, ProjectRole, Guid, ProjectUserLogin, ProjectUserRole, ProjectUserClaim>, IProjectContext
    {
        public ProjectDbContext()
            : base("StringConnection")
        {
        }
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Identity
            modelBuilder.Entity<ProjectUser>().ToTable("Users");
            modelBuilder.Entity<ProjectRole>().ToTable("Roles");
            modelBuilder.Entity<ProjectUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<ProjectUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<ProjectUserClaim>().ToTable("UserClaims");

            // Configurations
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new GalleryMap());
            modelBuilder.Configurations.Add(new UserMap());

            // Conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
