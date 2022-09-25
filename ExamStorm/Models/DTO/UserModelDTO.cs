using ExamStorm.DataManager.Models;

namespace ExamStorm.Models.DTO
{
    public class UserModelDTO
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
