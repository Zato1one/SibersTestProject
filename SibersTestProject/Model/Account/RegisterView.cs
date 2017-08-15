using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Account
{
    public class RegisterView
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        public string PasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}