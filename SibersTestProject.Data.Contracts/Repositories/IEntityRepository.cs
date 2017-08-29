using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SibersTestProject.Data.Contracts.Repositories
{
    public interface IEntityRepository { };
    public interface IEntityRepository<T> : IEntityRepository
    {
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        //IQueryable<T> Include(Expression<Func<T, object>> predicate);
        IQueryable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
    }
}
