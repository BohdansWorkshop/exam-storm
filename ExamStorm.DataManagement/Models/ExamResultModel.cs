using ExamStorm.DataManager.Models.Exam;
using System.Collections.Generic;

namespace ExamStorm.DataManager.Models
{
    public class ExamResultModel : BaseModel
    {
        public ExamModel Exam { get; set; }
        public UserModel User { get; set; }
        public int CorrectAnswersAmount { get; set; }
    }
}
