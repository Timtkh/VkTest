namespace VKAPITest.TestSolution.Models
{
    public record User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string AccessToken { get; set; }
    }
}