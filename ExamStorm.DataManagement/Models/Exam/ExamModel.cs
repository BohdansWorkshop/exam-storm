using System.Collections.Generic;

namespace ExamStorm.DataManager.Models.Exam
{
    public class ExamModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeInSeconds { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
