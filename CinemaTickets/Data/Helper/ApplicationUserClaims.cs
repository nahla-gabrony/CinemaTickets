using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Helper
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaims(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var idenity = await base.GenerateClaimsAsync(user);
            idenity.AddClaim(new Claim("UserFirstName", user.FirstName ?? ""));
            idenity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));
            return idenity;
        }
    }
}
