using System.Text.Json.Serialization;

namespace ExamStorm.DataManager.Models.Exam
{
    public class AnswerModel : BaseModel
    {
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        [JsonIgnore]
        public QuestionModel Question { get; set; }
    }
}
