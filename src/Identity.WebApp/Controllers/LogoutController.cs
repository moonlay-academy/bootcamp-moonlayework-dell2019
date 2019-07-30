using IdentityWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.WebApp.Controllers
{
    public class LogoutController : Controller
    {
        private readonly SignInManager<ApplicationUser> _manager;

        public LogoutController(SignInManager<ApplicationUser> manager)
        {
            _manager = manager;
        }

        public ActionResult Index(string redirect)
        {
            _manager.SignOutAsync().Wait();

            return Redirect(redirect);
        }
    }
}
