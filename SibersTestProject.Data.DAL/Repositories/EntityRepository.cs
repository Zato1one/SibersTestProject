using SibersTestProject.Data.Contracts.Context;
using SibersTestProject.Data.Contracts.Repositories;
using SibersTestProject.Data.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.DAL.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;

        protected readonly DbSet<T> DbSet;

        public EntityRepository(IProjectDbContext dbContext)
        {
            Context = dbContext.DbContext;
            DbSet = Context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.Where(entity => !entity.IsArchive);
        }

        public IQueryable<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public T GetById(object id)
        {
            var entity = DbSet.Find(id);
            if (entity != null && entity.IsArchive == false) return entity;
            return null;
        }

        public void Insert(T entity)
        {
            entity.DateCreated = DateTime.UtcNow;
            entity.LastModifiedDate = DateTime.UtcNow;
            var entityEntry = Context.Entry(entity);
            if (entityEntry.State != EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            entity.LastModifiedDate = DateTime.UtcNow;
            var entityEntry = Context.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            entityEntry.State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity != null)
                Delete(entity);
        }

        public void Delete(T entity)
        {
            entity.IsArchive = true;
            Update(entity);
        }

    }
}
