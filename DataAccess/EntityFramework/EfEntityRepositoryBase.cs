using Core.DataAccess;
using Core.Entities;
using DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected readonly BlogContext _context;
        private DbSet<TEntity> _dbSet;

        public EfEntityRepositoryBase(BlogContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.SingleOrDefaultAsync(filter);
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? await _dbSet.ToListAsync()
                : await _dbSet.Where(filter).ToListAsync();
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
