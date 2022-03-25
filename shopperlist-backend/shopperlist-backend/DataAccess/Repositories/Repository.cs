using Microsoft.EntityFrameworkCore;
using shopperlist_backend.DataAccess.Interfaces;
using shopperlist_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace shopperlist_backend.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>  where TEntity : class
    {
        private readonly DbContext _context;
        public Repository(shopperlistContext context)
        {
            _context = context;
        }
        public TEntity FirtsOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> VerifyAnd(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, object obj)
        {
            if (!String.IsNullOrEmpty(obj.ToString()) || !String.IsNullOrWhiteSpace(obj.ToString()))
            {
                return _context.Set<TEntity>().Where(predicate);
            }
            return _context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
