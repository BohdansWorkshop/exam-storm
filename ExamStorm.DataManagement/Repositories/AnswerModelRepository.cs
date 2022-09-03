using ExamStorm.DataManager.Models.Exam;

namespace ExamStorm.DataManager.Repositories
{
    public class AnswerModelRepository : BaseModelRepository<AnswerModel>
    {
        public AnswerModelRepository(ExamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
