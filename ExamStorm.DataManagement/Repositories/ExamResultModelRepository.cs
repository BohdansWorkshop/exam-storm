using ExamStorm.DataManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Repositories
{
    public class ExamResultModelRepository : BaseModelRepository<ExamResultModel>
    {
        public ExamResultModelRepository(ExamDbContext dbContext) : base(dbContext) { }

        public override async Task<List<ExamResultModel>> GetWhereAsync(Expression<Func<ExamResultModel, bool>> query)
        {
            return await base.dbSet
                .Where(query)
                .Include(u => u.User)
                .Include(e=>e.Exam)
                .ThenInclude(e => e.Questions)
                .ToListAsync();
        }
    }
}
