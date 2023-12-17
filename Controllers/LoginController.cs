using Microsoft.AspNetCore.Mvc;
using TyeBank.Business;
using TyeBank.Interfaces;
using TyeBank.Models.DTOs;

namespace TyeBank.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginBusiness _loginBusiness;
        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View("Views/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            loginDTO.HashedPassword = _loginBusiness.GetHashedPassword(loginDTO.Password, PasswordHash.PasswordHash.Base64Encode("TyeBank"));

           var loginViewModel =  _loginBusiness.Login(loginDTO); 


            return View(loginViewModel);
        }
    }
}
