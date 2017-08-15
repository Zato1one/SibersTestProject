using SibersTestProject.Common.Model;
using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SibersTestProject.Logic.Contracts.Service
{
    public interface IAccountService : IService
    {
        Task<IdentityResultModel> RegisterUser(UserModel userModel);
    }
}
