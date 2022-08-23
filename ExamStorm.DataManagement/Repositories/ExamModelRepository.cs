using ExamStorm.DataManager.Models.Exam;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Repositories
{
    public class ExamModelRepository : BaseModelRepository<ExamModel>
    {
        public ExamModelRepository(ExamDbContext dbContext) : base(dbContext) { }

        public override async Task<ExamModel> GetByIdAsync(Guid id)
        {
            return await base.dbSet
                .Include(q => q.Questions)
                .ThenInclude(o => o.Options)
                .FirstAsync(x => x.Id == id);
        }
    }
}
