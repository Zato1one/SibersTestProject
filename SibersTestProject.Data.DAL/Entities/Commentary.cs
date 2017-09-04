using SibersTestProject.Data.DAL.Entities.Base;
using SibersTestProject.Data.DAL.Identity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.DAL.Entities
{
    public class Commentary : BaseEntity
    {
        [Required]
        public string Comment { get; set; }
        public Guid PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
        public Guid UserId { get; set; }
        public virtual ProjectUser User { get; set; }
    }
}
