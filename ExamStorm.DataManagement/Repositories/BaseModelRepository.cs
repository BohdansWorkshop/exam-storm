using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(T model)
        {
            var result = false;
            var removalState = dbSet.Remove(model);
            if(removalState.State == EntityState.Deleted)
            {
                await this.dbContext.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<T> AddOrUpdateAsync(T model)
        {
            dbSet.Update(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public Task<T> UpdateModelAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}
