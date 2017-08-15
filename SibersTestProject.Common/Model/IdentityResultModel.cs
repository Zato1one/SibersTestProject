using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Common.Model
{
    public class IdentityResultModel
    {
        public IEnumerable<string> Errors { get; set; }
        public bool Succeeded { get; set; }
    }
}
