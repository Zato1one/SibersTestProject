using SibersTestProject.Data.Contracts.Context;
using SibersTestProject.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectDbContext Context { get; }
        IEntityRepository<T> GetRepository<T>();
        void RegisterEntityRepository<T>(T customRepository) where T : IEntityRepository;
        void SaveChanges();
    }
}
