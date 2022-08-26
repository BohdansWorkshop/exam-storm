namespace ExamStorm.DataManager.Models
{
    public class UserModel : BaseModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
    }

    public enum UserRole
    {
        Common = 1,
        Moderator = 2
    }
}
