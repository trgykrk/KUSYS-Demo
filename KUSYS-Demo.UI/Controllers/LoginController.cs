using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.Business.Services;
using KUSYS_Demo.DataAccess.Contexts;
using KUSYS_Demo.Dtos.UserDtos;
using KUSYS_Demo.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KUSYS_Demo.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet] 
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDtos dto)
        {
            var user = await _userService.GetByUsernameAndPassword(dto.UserName, dto.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(dto.UserName,dto.Password)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return user.RoleId == 1 ? RedirectToAction("Index", "Admin"): RedirectToAction("Index", "Student");
            }

            return View();
        }
    }
}
