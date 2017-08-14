using Microsoft.AspNet.Identity;
using SibersTestProject.Data.DAL.Identity.Entities;
using SibersTestProject.Data.DAL.Identity.Store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace SibersTestProject.Data.DAL.Context
{
    public sealed class ProjectDbContextConfiguration : DropCreateDatabaseIfModelChanges<ProjectDbContext>
    {
        //public ProjectDbContextConfiguration()
        //{
        //    AutomaticMigrationsEnabled = false;
        //}

        protected override void Seed(ProjectDbContext context)
        {
            // init users and roles manager
            var userManager = new UserManager<ProjectUser, Guid>(new ProjectUserStore(context));
            var roleManager = new RoleManager<ProjectRole, Guid>(new ProjectRoleStore(context));

            //system role list
            var roles = new List<string>() { "SuperAdmin", "UserAdmin", "User" };

            //Create system role if notExist
            roles.ForEach(roleName => {
                if (!roleManager.RoleExists(roleName))
                {
                    roleManager.Create(new ProjectRole(roleName));
                }
            });

            //system SuperAdmin
            var admin = new ProjectUser()
            {
                Id = new Guid("1ABB568A-2ECD-43E6-B814-BE164CF2F6F4"),
                Email = "SuperAdmin@gmail.com",
                UserName = "SuperAdmin",
                FirstName = "SuperAdminFirstName",
                LastName = "SuperAdminLastName"
            };
            var adminPassword = "SuperAdminPassword";
            //Create system SuperAdmin if notExist
            if (userManager.FindByName(admin.UserName) == null)
            {
                userManager.Create(admin, adminPassword);
                userManager.SetLockoutEnabled(admin.Id, false);
            }

            // Add SuperAdmin to role if not already added
            var adminRole = "SuperAdmin";
            var rolesForUser = userManager.GetRoles(admin.Id);
                if (!rolesForUser.Contains(adminRole))
                    userManager.AddToRole(admin.Id, adminRole);

            base.Seed(context);
        }
    }
}
