using SibersTestProject.Data.Contracts;
using SibersTestProject.Logic.Contracts;
using SibersTestProject.Logic.Contracts.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.BL.Service.Base
{
    public abstract class HostService<T> : IService where T : IService
    {
        /// <summary>
        /// The unit of work.
        /// </summary>
        protected readonly IUnitOfWork UnitOfWork;
        /// <summary>
        /// Creates 
        /// </summary>
        /// <param name="servicesHost"></param>
        /// <param name="unitOfWork"></param>
        protected HostService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            servicesHost.Register((T)(this as IService));
        }
    }
}
