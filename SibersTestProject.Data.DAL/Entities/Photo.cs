using SibersTestProject.Data.DAL.Entities.Base;
using SibersTestProject.Data.DAL.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SibersTestProject.Data.DAL.Entities
{
    public class Photo : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public byte[] Image { get; set; }
        public Guid UserId { get; set; }
        public virtual ProjectUser User { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
  
    }
}
