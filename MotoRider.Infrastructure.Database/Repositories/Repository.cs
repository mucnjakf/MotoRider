using Microsoft.EntityFrameworkCore;
using MotoRider.Infrastructure.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MotoRider.Infrastructure.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id) => Context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll() => Context.Set<TEntity>().ToList();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().Where(predicate);

        public void Add(TEntity entity) => Context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities) => Context.Set<TEntity>().AddRange(entities);

        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

        public void RemoveRange(TEntity entities) => Context.Set<TEntity>().RemoveRange(entities);
    }
}
