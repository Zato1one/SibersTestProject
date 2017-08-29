using SibersTestProject.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Admin
{
    public class ChangeRoleView
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public IList<string> CurentRole { get; set; }
        public RoleNameEnume RoleName { get; set; }
    }  
}