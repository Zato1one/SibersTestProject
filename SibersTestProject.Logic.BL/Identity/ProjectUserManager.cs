using Microsoft.AspNet.Identity;
using SibersTestProject.Data.DAL.Context;
using SibersTestProject.Data.DAL.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.BL.Identity
{
    public class ProjectUserManager : UserManager<ProjectUser, Guid>
    {
        public ProjectUserManager(IUserStore<ProjectUser, Guid> store)
            : base(store)
        {

            // Configure validation logic for usernames
            this.UserValidator = new UserValidator<ProjectUser, Guid>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = false
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

        }     
    }
}
