﻿using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Repositories
{
    public class BaseModelRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public BaseModelRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }

        public async Task<T> GetModelByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> RemoveModelAsync(T model)
        {
            var result = false;
            var removalState = dbSet.Remove(model);
            if(removalState.State == EntityState.Deleted)
            {
                result = true;
                await this.dbContext.SaveChangesAsync();
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