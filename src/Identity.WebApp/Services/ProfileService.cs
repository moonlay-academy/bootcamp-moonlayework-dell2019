using Identity.WebApp.Models;
using Identity.WebApp.Services;
using IdentityModel;
using IdentityServer4.Models;
using IdentityWeb.Models;
using Microsoft.AspNetCore.Identity;
using SqlKata;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityWeb.Services
{
    public class ProfileService : IdentityServer4.Services.IProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEWorkConnection _eWorkConnection;

        public ProfileService(UserManager<ApplicationUser> userManager, IEWorkConnection eWorkConnection)
        {
            _userManager = userManager;
            _eWorkConnection = eWorkConnection;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            var employeeSet = _eWorkConnection.Query("Employees");
            var employee = await employeeSet.Where("Username", "=", user.UserName).Select("Id", "FullName", "Username").FirstOrDefaultAsync<EmployeeEWork>();

            if(employee != null)
            {
                if (!string.IsNullOrEmpty(employee.FullName))
                    context.IssuedClaims.Add(new Claim(JwtClaimTypes.Name, employee.FullName));

                context.IssuedClaims.Add(new Claim("EmployeeId", employee.Id.ToString()));
            }
           
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null);
        }
    }
}