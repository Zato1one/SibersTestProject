using SibersTestProject.Data.Contracts;
using SibersTestProject.Data.Contracts.Context;
using SibersTestProject.Data.Contracts.Repositories;
using SibersTestProject.Data.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, IEntityRepository> enityRepositories;
        private readonly object lockObject = new object();
        public IProjectDbContext Context { get; private set; }


        public UnitOfWork(IProjectDbContext context)
        {
            enityRepositories = new Dictionary<Type, IEntityRepository>();
            Context = context;
        }
        public void RegisterEntityRepository<T>(T enityRepository) where T : IEntityRepository
        {
            if (!enityRepositories.ContainsKey(typeof(T)))
                enityRepositories.Add(typeof(T), enityRepository);
        }
        public IEntityRepository<T> GetRepository<T>()
        {
            if (enityRepositories.ContainsKey(typeof(T)))
                return enityRepositories[typeof(T)] as IEntityRepository<T>;
            var repositoryType = typeof(EntityRepository<>).MakeGenericType(typeof(T));
            var repository = (IEntityRepository<T>)Activator.CreateInstance(repositoryType, this.Context);
            enityRepositories.Add(typeof(T), repository);

            return repository;
        }

        public void SaveChanges()
        {
            //try
            //{
                lock (lockObject)
                {
                    this.Context.DbContext.SaveChanges();
                }
            //}
            //catch { }
        }
    }
}
