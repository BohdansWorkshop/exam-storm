using System;
using System.Collections.Generic;
using System.Text;

namespace ExamStorm.DataManager.Models.Exam
{
    public class ExamModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
