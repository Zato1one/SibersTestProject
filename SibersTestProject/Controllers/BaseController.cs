using SibersTestProject.Logic.BL.Identity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using SibersTestProject.Logic.Contracts;

namespace SibersTestProject.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServicesHost ServicesHost;
        public BaseController(IServicesHost servicesHost)
        {
            this.ServicesHost = servicesHost;
        }
        protected ProjectUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ProjectUserManager>();
            }
        }

        protected ProjectRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ProjectRoleManager>();
            }
        }
        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}