namespace PCBuilder.Models.Request
{
    public class UserSignUpRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
        public string Password { get; set; }
    }
}
