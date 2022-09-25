using System.Collections.Generic;

namespace ExamStorm.Models.DTO
{
    public class ExamResultsDTO
    {
        public string ExamId { get; set; }
        public Dictionary<string, string> QuestionIdToAnswerIdMap { get; set; }
    }
}
