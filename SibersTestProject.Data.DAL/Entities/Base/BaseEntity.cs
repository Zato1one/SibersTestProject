using System;
using System.ComponentModel.DataAnnotations;


namespace SibersTestProject.Data.DAL.Entities.Base
{
    public abstract class BaseEntity
    {
        public bool IsArchive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
