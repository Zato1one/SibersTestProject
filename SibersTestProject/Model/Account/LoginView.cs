using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Account
{
    public class LoginView
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Логин")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}