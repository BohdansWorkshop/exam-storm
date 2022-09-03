using System.Collections.Generic;

namespace ExamStorm.ModelsDTO
{
    public class ExamResultsDTO
    {
        public string ExamId { get; set; }
        public Dictionary<string, string> QuestionIdToAnswerIdMap { get; set; }
    }
}
