using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace shopperlist_backend.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FirtsOrDefault(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        TEntity Insert(TEntity entity);
        IQueryable<TEntity> GetAll();

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> VerifyAnd(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, object obj);

        void SaveChanges();



    }
}
