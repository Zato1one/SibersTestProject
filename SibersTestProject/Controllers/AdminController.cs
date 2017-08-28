using SibersTestProject.Common.Enums;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SibersTestProject.Controllers
{
    [Authorize(Roles = RoleName.SuperAdmin)]
    public class AdminController : BaseController
    {
        public AdminController(IServicesHost servicesHost)
            : base(servicesHost) {
        }
        // GET: Admin
        public async Task<ActionResult> ChangeRole(Guid id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var viewModel = new ChangeRole()
            {
                userId = id,
                UserName = user.UserName,
                CurentRole = await UserManager.GetRolesAsync(id)
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeRole(ChangeRole viewModel)
        {
            await UserManager.RemoveFromRolesAsync(viewModel.userId, viewModel.CurentRole.ToArray());
            await UserManager.AddToRoleAsync(viewModel.userId, viewModel.RoleName.ToString());
            return RedirectToAction("Index","Home");
        }


    }
}