using ExamStorm.DataManager.Models.Exam;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamStorm.DataManager.Repositories
{
    public class ExamModelRepository : BaseModelRepository<ExamModel>
    {
        public ExamModelRepository(ExamDbContext dbContext) : base(dbContext) { }

        public override async Task<List<ExamModel>> Get(int skip, int take)
        {
            return await base.dbSet
                .Include(q => q.Questions)
                .ThenInclude(o => o.Answers)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
        public override async Task<ExamModel> GetByIdAsync(Guid id)
        {
            return await base.dbSet
                .Include(q => q.Questions)
                .ThenInclude(o => o.Answers)
                .FirstAsync(x => x.Id == id);
        }
    }
}
