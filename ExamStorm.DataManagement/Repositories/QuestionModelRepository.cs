using ExamStorm.DataManager.Models.Exam;

namespace ExamStorm.DataManager.Repositories
{
    public class QuestionModelRepository : BaseModelRepository<QuestionModel>
    {
        public QuestionModelRepository(ExamDbContext dbContext) : base(dbContext)
        {
        }
    }
}
