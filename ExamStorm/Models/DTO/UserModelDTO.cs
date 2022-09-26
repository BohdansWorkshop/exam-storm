using ExamStorm.DataManager.Models;
using System.Collections.Generic;

namespace ExamStorm.Models.DTO
{
    public class UserModelDTO
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        List<ExamResultModel> ExamResults { get; set; }
    }
}
