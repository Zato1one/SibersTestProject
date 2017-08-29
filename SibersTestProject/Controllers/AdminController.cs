using AutoMapper;
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

        public async Task<ActionResult> ChangeRole(Guid id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var chageRoleView = Mapper.Map<ChangeRoleView>(user);
            chageRoleView.CurentRole = await UserManager.GetRolesAsync(id);

            return View(chageRoleView);
        }
        [HttpPost]
        public async Task<ActionResult> ChangeRole(ChangeRoleView viewModel)
        {
            await UserManager.RemoveFromRolesAsync(viewModel.Id, viewModel.CurentRole.ToArray());
            await UserManager.AddToRoleAsync(viewModel.Id, viewModel.RoleName.ToString());

            return RedirectToAction("Index", "Home");
        }


    }
}