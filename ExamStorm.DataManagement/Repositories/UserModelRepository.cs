using ExamStorm.DataManager.Models;

namespace ExamStorm.DataManager.Repositories
{
    public class UserModelRepository : BaseModelRepository<UserModel>
    {
        public UserModelRepository(ExamDbContext dbContext) : base(dbContext) { }
    }
}
