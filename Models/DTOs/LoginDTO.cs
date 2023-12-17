namespace TyeBank.Models.DTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HashedPassword { get; set; }
    }
}
