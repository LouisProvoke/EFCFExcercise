using EFCFExcercise.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCFExcercise.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected EFCFExcerciseContext _context;
        protected readonly ILogger _logger;
        internal DbSet<T> _dbSet;

        public GenericRepository(EFCFExcerciseContext context, ILogger logger)
        {
            this._context = context;
            this._logger = logger;
            this._dbSet = context.Set<T>();
        }

        

        public virtual async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> result = await _dbSet.ToListAsync();
            return result;
        }

        public virtual async Task<T?> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }
    }
}
