using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.Contracts
{
    public interface IServicesHost
    {
        void Register<T>(T service) where T : IService;
        T GetService<T>() where T : IService;
    }
}
