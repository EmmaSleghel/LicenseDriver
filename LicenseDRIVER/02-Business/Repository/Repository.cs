using Business.Infrastructure;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class 
    {
        private readonly DatabaseContext dataContext;
        private readonly DbSet<TEntity> dbset;


        public Repository(DatabaseContext dbContext)
        {
            dataContext = dbContext;
            dbset = dataContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            dbset.Remove(entity);
        }

        public virtual TEntity GetByKey(params object[] keyValues)
        {
            return dbset.Find(keyValues);
        }
    
        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbset;

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            return query;
        }

        public List<TResult> ExecuteQuery<TResult>(string sqlQuery, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}

