using Microsoft.AspNet.Identity;
using Owin;
using SibersTestProject.Data.Contracts.Context;
using SibersTestProject.Data.DAL.Identity.Entities;
using SibersTestProject.Data.DAL.Identity.Store;
using SibersTestProject.Logic.BL.Identity;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

namespace SibersTestProject
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<IProjectDbContext>());

            app.CreatePerOwinContext<IRoleStore<ProjectRole, Guid>>((options, context) =>
                new ProjectRoleStore(context.Get<IProjectDbContext>()));
            app.CreatePerOwinContext<IUserStore<ProjectUser, Guid>>((options, context) =>
                new ProjectUserStore(context.Get<IProjectDbContext>()));

            app.CreatePerOwinContext<ProjectUserManager>((options, context) => new ProjectUserManager(context.Get<IUserStore<ProjectUser, Guid>>()));

            app.CreatePerOwinContext<ProjectRoleManager>((options, context) => new ProjectRoleManager(context.Get<IRoleStore<ProjectRole, Guid>>()));
            //app.CreatePerOwinContext<MercurySignInManager>((options, context) => new MercurySignInManager(context.Get<MercuryUserManager>(), context.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}