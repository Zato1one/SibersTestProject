using SibersTestProject.Common.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Logic.Contracts.Service.Base
{
    public interface ICrudService<T> : IService where T : BaseModel
    {
        void Save(T model);
        void Delete(T model);
        void Delete(Guid modelId);
        List<T> GetAll();
        T GetById(Guid id);
    }
}
