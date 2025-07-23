using Aspire.Vetpaws.Lab.Models;
using Aspire.Vetpaws.Lab.Models.Login;
using Aspire.Vetpaws.Lab.Service.Login;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Aspire.Vetpaws.Lab.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(
            ILoginService loginService,
            IMapper mapper,
            ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                _logger.LogInformation("User {UserName} is already logged in.", User.Identity.Name);
                return RedirectToAction("Index", "Billing");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginUserModel user)
        {
            HttpContext.Session.Clear();

            if (ModelState.IsValid)
            {
                var userDto = _mapper.Map<LoginUser>(user);
                if (_loginService.ValidateUser(userDto))
                {
                    var loggedUser = _loginService.GetUserInfo(userDto.UserName);
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, loggedUser.UserName),
                            new Claim(ClaimTypes.Email, loggedUser.Email),
                            new Claim(ClaimTypes.Role, loggedUser.Role.ToString())
                        };
                    var identity = new ClaimsIdentity(claims, "LoginCookie");
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Billing");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    _logger.LogWarning("Invalid login attempt for user {UserName}.", user.UserName);

                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("User logged out successfully.");
            return RedirectToAction("Index", "Home");
        }
    }
}