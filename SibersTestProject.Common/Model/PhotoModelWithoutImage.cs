using SibersTestProject.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class PhotoModelWithoutImage : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}
