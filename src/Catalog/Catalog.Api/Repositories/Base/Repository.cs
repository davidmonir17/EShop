using Catalog.Api.Data;
using Catalog.Api.Entities;
using Catalog.Api.Repositories.Interfaces.IBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Product
    {
        protected readonly CatalogContext _dbcotext;
        public Repository(CatalogContext dbcontext)
        {
            _dbcotext = dbcontext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbcotext.Set<T>().ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbcotext.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            string includestring = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbcotext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(includestring)) query = query.Include(includestring);
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();

        }
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbcotext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();
            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));
            if (predicate != null) query = query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbcotext.Set<T>().FindAsync(id);

        }
        public async Task<T> AddAsync(T entity)
        {
            _dbcotext.Set<T>().Add(entity);
            await _dbcotext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbcotext.Entry(entity).State = EntityState.Modified;
            await _dbcotext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbcotext.Set<T>().Remove(entity);
            await _dbcotext.SaveChangesAsync();
        }
    }
}
