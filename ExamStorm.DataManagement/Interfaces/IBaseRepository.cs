using ExamStorm.DataManager.Models;
using System;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Interfaces
{
    public interface IBaseRepository<T> where T: BaseModel
    {
        Task<T> AddOrUpdateAsync(T model);
        Task<T> GetModelByIdAsync(Guid id);
        Task<bool> RemoveModelAsync(T model);
        Task<T> UpdateModelAsync(T model);
    }
}
