using TyeBank.Interfaces;
using TyeBank.Models.AppDbContext;
using TyeBank.Models.DTOs;
using TyeBank.Models.StoredProcedureResponses;
using TyeBank.Models.ViewModels;

namespace TyeBank.DataAccess
{
    public class LoginDataAccess : ILoginDataAccess
    {
        private readonly AppDbContext _context;
        public LoginDataAccess(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public LoginViewModel Login(LoginDTO loginDTO)
        {
            var results = _context.CallStoredProcedure<SP_LoginResponse>(
                "SP_Login",
                ("UserName", loginDTO.UserName),
                ("UserPasswordHash", loginDTO.HashedPassword));

            
            return new LoginViewModel();

        }
    }
}
