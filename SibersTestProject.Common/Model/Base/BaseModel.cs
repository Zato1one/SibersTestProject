using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model.Base
{
    public class BaseModel
    {
        public BaseModel()
        {
            EntityId = Guid.NewGuid();
        }
        public Guid EntityId { get; set; }
        public bool IsArchive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
