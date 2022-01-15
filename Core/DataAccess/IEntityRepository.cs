﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    }
}
