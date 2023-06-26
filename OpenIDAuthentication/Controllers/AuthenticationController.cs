using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OpenIDAuthentication.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
            // Do some authentication stuff here
            var username = Request.Form["username"][0].ToString();
            var password = Request.Form["password"][0].ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.Name, username)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
              AllowRefresh = true,
              IsPersistent = true,
              IssuedUtc = DateTime.UtcNow,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
              new ClaimsPrincipal(claimsIdentity),
              authProperties);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Home");  //Add a button for this.
        }
    }
}
