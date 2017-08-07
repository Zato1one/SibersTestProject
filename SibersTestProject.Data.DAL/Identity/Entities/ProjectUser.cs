using Microsoft.AspNet.Identity.EntityFramework;
using SibersTestProject.Data.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SibersTestProject.Data.DAL.Identity.Entities
{
    public class ProjectUser : IdentityUser<Guid, ProjectUserLogin, ProjectUserRole, ProjectUserClaim>
    {
        public ProjectUser()
        {
            Id = Guid.NewGuid();
        }

        public ProjectUser(string userName)
            : this()
        {
            UserName = userName;
        }

        [Required]
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(60)]
        public string LastName { get; set; }
  
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }

    }
}
