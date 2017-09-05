using SibersTestProject.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class CommentaryModel : BaseModel
    {
        public string Comment { get; set; }
        public string UserName { get; set; }
        public Guid PhotoId { get; set; }
        public Guid UserId { get; set; }
    }
}
