using Microsoft.AspNet.Identity;
using SibersTestProject.Common.Model;
using SibersTestProject.Logic.BL.Identity;
using SibersTestProject.Logic.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Host.SystemWeb;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using AutoMapper;
using SibersTestProject.Data.DAL.Identity.Entities;
using SibersTestProject.Logic.BL.Service.Base;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Data.Contracts;
using System.Net;
using Microsoft.Owin.Security;

namespace SibersTestProject.Logic.BL.Service
{
    public class AccountService : HostService<IAccountService>, IAccountService
    {
        public AccountService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {
        }
        public async Task<IdentityResultModel> RegisterUser(UserModel userModel)
        {
            var httpContext = HttpContext.Current;
            var UserManager = httpContext.GetOwinContext().GetUserManager<ProjectUserManager>();

            var dbUser = Mapper.Map<ProjectUser>(userModel);
            var identityResult = await UserManager.CreateAsync(dbUser, userModel.Password);
            if (identityResult.Succeeded)
            {
                //await CreateRole(dbUser.Id,"User");
                await UserManager.AddToRoleAsync(dbUser.Id, "User");
            }
            await SignIn(dbUser);
            return Mapper.Map<IdentityResultModel>(identityResult);
        }
        private async Task CreateRole(Guid userId, string roleName)
        {
            var httpContext = HttpContext.Current;
            var UserManager = httpContext.GetOwinContext().GetUserManager<ProjectUserManager>();

            await UserManager.AddToRoleAsync(userId, roleName);
        }
        private async Task SignIn(ProjectUser user)
        {
            var httpContext = HttpContext.Current;
            var UserManager = httpContext.GetOwinContext().GetUserManager<ProjectUserManager>();
            var ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            httpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, ident);
        }

    }
}
