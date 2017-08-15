using SibersTestProject.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class UserModel : BaseModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
