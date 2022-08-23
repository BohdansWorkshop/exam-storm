using System.Text.Json.Serialization;

namespace ExamStorm.DataManager.Models.Exam
{
    public class OptionModel : BaseModel
    {
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        [JsonIgnore]
        public QuestionModel Question { get; set; }
    }
}
