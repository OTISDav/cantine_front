namespace FrontendApp.Models
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string? UserId { get; set; }
        public string FullName { get; set; } = "";
        public string? Role { get; set; }
    }
}
