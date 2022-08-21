using ExamStorm.DataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamStorm.DataManager.Repositories
{
    public class UserModelRepository : BaseModelRepository<UserModel>
    {
        public UserModelRepository(DbContext dbContext) : base(dbContext) { }
    }
}
