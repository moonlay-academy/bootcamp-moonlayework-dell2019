using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Backend.WebApp.Controllers
{
    public class LogoutController : Controller
    {
        private readonly IConfiguration _configuration;

        public LogoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult Index()
        {
            HttpContext.SignOutAsync().Wait();

            var identityServerAuthUrl = _configuration.GetValue<string>("IdentityServerAuthorizeUrl");
            var selfUrl = "https://localhost:42342";

            return Redirect(identityServerAuthUrl + $"/logout?redirect={selfUrl}");
        }
    }
}
