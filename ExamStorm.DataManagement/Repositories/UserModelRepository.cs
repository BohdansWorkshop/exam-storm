using ExamStorm.DataManager.Models;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Repositories
{
    public class UserModelRepository : BaseModelRepository<UserModel>
    {
        public UserModelRepository(ExamDbContext dbContext) : base(dbContext) { }

        public override async Task<UserModel> UpdateAsync(UserModel model)
        {
            dbSet.Update(model);
            dbContext.Entry(model).Property(x => x.Password).IsModified = false;
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}
