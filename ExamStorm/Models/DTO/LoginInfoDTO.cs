using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExamStorm.Models.DTO
{
    public class LoginInfoDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
