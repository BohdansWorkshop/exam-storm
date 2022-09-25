using ExamStorm.DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Interfaces
{
    public interface IBaseRepository<T> where T: BaseModel
    {
        Task<List<T>> Get(int skip, int take);
        Task<T> GetOneWhere(Expression<Func<T, bool>> query);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<bool> RemoveAsync(T model);

    }
}
