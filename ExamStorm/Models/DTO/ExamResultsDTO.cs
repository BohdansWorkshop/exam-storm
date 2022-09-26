using System.Collections.Generic;

namespace ExamStorm.Models.DTO
{
    public class ExamSummaryDTO
    {
        public string ExamId { get; set; }
        public Dictionary<string, string> QuestionIdToAnswerIdMap { get; set; }
    }
}
