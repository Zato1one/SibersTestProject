using System;
using System.ComponentModel.DataAnnotations;


namespace SibersTestProject.Data.DAL.Entities.Base
{
    public abstract class BaseEntity
    {
        [Required]
        public bool IsArchive { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
