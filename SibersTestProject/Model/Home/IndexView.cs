using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SibersTestProject.Model.Home
{
    public class UserView
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<string> CurentRole { get; set; }
    }
}