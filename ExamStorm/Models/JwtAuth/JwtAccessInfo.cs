using System.Text.Json.Serialization;

namespace ExamStorm.Models.JwtAuth
{
    public class JwtAccessInfo
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}
