using SibersTestProject.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace SibersTestProject.Common.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this IIdentity identity)
        {
            Guid result;
            return Guid.TryParse(identity.GetUserId<string>(), out result) ? result : Guid.Empty;
        }
    }
}
