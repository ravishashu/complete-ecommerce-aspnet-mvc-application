﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ETickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T,object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T actor);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);

    }
}
