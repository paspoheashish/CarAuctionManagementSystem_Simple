namespace AuthService.Application.DTOs
{
    public class UserValidationResponse
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

}
