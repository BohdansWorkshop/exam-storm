using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Repositories
{
    public class BaseModelRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected DbSet<T> dbSet;
        protected DbContext dbContext;

        public BaseModelRepository(ExamDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }

        public virtual async Task<List<T>> Get(int skip, int take)
        {
            return await dbSet
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
   
        public virtual async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> query)
        {
            return await dbSet.Where(query).ToListAsync();
        }

        public virtual async Task<T> GetOneWhereAsync(Expression<Func<T, bool>> query)
        {
            return await dbSet.FirstOrDefaultAsync(query);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<T> UpdateAsync(T model)
        {
            dbSet.Update(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public virtual async Task<bool> RemoveAsync(T model)
        {
            var result = false;
            var removalState = dbSet.Remove(model);
            if (removalState.State == EntityState.Deleted)
            {
                await dbContext.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public virtual async Task<T> AddAsync(T model)
        {
            await dbSet.AddAsync(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}
