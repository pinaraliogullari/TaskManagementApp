using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagement.Application.Dtos;
using TaskManagement.Application.Requests;

namespace TaskManagement.UI.Controllers
{
    public class AccountController : Controller
    {

        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginRequest("", ""));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess && result.Data is not null)
            {
                await SetAuthCookie(result.Data, request.RememberMe);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Unknown error occured.Please contact with system provider.");
                }
                return View(request);
            }

        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync
                (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private async Task SetAuthCookie(LoginResponseDto dto, bool rememberMe)
        {
            var claims = new List<Claim>
        {
            new Claim("Name", dto.Name),
            new Claim("Surname", dto.Surname),
            new Claim(ClaimTypes.Role, dto.Role.ToString()),
        };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

    }
}
