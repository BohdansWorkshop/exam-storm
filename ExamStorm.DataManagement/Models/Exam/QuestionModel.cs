using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExamStorm.DataManager.Models.Exam
{
    public class QuestionModel : BaseModel
    {
        public string Question { get; set; }
        public string Explanation { get; set; }
        public List<AnswerModel> Answers { get; set; }

        [JsonIgnore]
        public ExamModel Exam { get; set; }
    }
}
