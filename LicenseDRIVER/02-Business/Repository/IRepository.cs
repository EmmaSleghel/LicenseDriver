using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetByKey(params object[] keyValues);
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includeProperties);
        List<TResult> ExecuteQuery<TResult>(string sqlQuery, params object[] parameters);
    }
}
