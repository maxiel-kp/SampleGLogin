using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace SampleGLogin.Controllers
{
    public class AuthController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public void ConfigureAuthenticationServices(IServiceCollection services)
        {
            AuthenticationBuilder builder = services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "Google"; // Use a custom scheme name
            });

            builder.AddCookie();
            builder.AddGoogle("Google", options =>
            {
                options.ClientId = "YOUR_CLIENT_ID";
                options.ClientSecret = "YOUR_CLIENT_SECRET";
            });
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
