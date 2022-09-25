namespace ExamStorm.DataManager.Models
{
    public class UserModel : BaseModel
    {
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; } = UserRole.Common;
        public string Password { get; set; }
    }

    public enum UserRole
    {
        Common = 1,
        Moderator = 2
    }
}
