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
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password is not required")]
        [DataType(DataType.Password)]
        [Display(Name = "RepeatPassword")]
        public string PasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}