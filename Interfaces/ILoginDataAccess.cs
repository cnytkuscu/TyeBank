using TyeBank.Models.DTOs;
using TyeBank.Models.ViewModels;

namespace TyeBank.Interfaces
{
    public interface ILoginDataAccess
    {
        public LoginViewModel Login(LoginDTO loginDTO);
    }
}
