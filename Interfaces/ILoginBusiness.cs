using TyeBank.Models.DTOs;
using TyeBank.Models.ViewModels;

namespace TyeBank.Interfaces
{
    public interface ILoginBusiness
    {
        public string GetHashedPassword(string password, string salt);

        public LoginViewModel Login(LoginDTO loginDTO);
    }
}
