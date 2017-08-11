using SibersTestProject.Logic.BL;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.BL
{
    public class ServicesHost : IServicesHost
    {
        private readonly Dictionary<Type, IService> services = new Dictionary<Type, IService>();
        public void Register<T>(T service) where T : IService
        {
            if (!services.ContainsKey(typeof(T)))
                services.Add(typeof(T), service);
        }
        public T GetService<T>() where T : IService
        {
            if (services.ContainsKey(typeof(T)))
                return (T)services[typeof(T)];
            return default(T);
        }
    }
}
