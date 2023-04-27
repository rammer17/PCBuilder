namespace PCBuilder.Models.Request
{
    public class UserSignUpRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
