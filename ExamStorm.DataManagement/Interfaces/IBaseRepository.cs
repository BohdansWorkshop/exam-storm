using ExamStorm.DataManager.Models;
using System;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Interfaces
{
    public interface IBaseRepository<T> where T: BaseModel
    {
        Task<T> AddOrUpdateAsync(T model);
        Task<T> GetByIdAsync(Guid id);
        Task<bool> RemoveAsync(T model);
        Task<T> UpdateModelAsync(T model);
    }
}
