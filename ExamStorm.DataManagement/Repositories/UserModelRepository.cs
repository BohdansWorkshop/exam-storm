using ExamStorm.DataManager.Models;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public override async Task<UserModel> GetOneWhereAsync(Expression<Func<UserModel, bool>> query)
        {
            return await base.dbSet
                .Include(userModel => userModel.ExamResults)
                .ThenInclude(exResModel => exResModel.Exam)
                .FirstOrDefaultAsync(query);
        }
    }
}
