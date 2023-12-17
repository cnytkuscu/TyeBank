using TyeBank.Interfaces;
using TyeBank.Models.DTOs;
using TyeBank.Models.ViewModels;

namespace TyeBank.Business
{
    public class LoginBusiness : ILoginBusiness
    {
        private readonly ILoginDataAccess _loginDataAccess;

        public LoginBusiness(ILoginDataAccess loginDataAccess)
        {
            _loginDataAccess = loginDataAccess;
        }

        public string GetHashedPassword(string password, string salt)
        {
            return PasswordHash.PasswordHash.HashPassword(password, salt);
        }

        public LoginViewModel Login(LoginDTO loginDTO)
        {
            var returnData = _loginDataAccess.Login(loginDTO);

            return new LoginViewModel();
        }
    }
}
