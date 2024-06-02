namespace MoneyFellows.Application.Dtos.Accounts.Login
{
    public class LoginDto
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
