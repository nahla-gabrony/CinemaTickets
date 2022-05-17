using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.User;
using CinemaTickets.Data.Helper;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly CinemaTicketsContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IHttpContextAccessor httpContext,
                            CinemaTicketsContext context,
                            RoleManager<IdentityRole> roleManager,
                            UserManager<ApplicationUser> userManager)
        {
            _httpContext = httpContext;
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public int Count()
        {
            return _userManager.Users.Count();
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public bool IsAuthenticated()
        {
            return _httpContext.HttpContext.User.Identity.IsAuthenticated;
        }
        public async Task<ApplicationUser> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
        public async Task<IdentityResult> Delete(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user); 
        }
        public async Task<UserViewModel> CheckExistingUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userClaims = await _userManager.GetClaimsAsync(user);
                var model = new UserViewModel
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Roles = userRoles,
                    Claims = userClaims.Select(c => c.Value).ToList()
                };

                return model;
            }
            else
            {
                return null;
            }
        }
        public async Task<IdentityResult> UpdateUserById(UserViewModel model, ApplicationUser user)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Email;
            return await _userManager.UpdateAsync(user);
        }
        public PagedResult<ApplicationUser> GetUserByPages(int page, string search = "")
        {
            var users = _userManager.Users;
            if (users != null)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return users.Where(u => u.FirstName.Contains(search) || u.LastName.Contains(search) || u.Email.Contains(search)).GetPaged(page, 3);
                }
                return users.GetPaged(page, 3);
            }
            return null;
        }
        /* -------------------------------------   User/Role Part  -----------------------------------*/

        public async Task<List<UserRolesViewModel>> GetRolesofUser(ApplicationUser user)
        {
            if (user != null)
            {
                var model = new List<UserRolesViewModel>();

                foreach (var role in _roleManager.Roles.ToList())
                {
                    var userRolesViewModel = new UserRolesViewModel
                    {
                        RoleId = role.Id,
                        RoleName = role.Name
                    };

                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRolesViewModel.IsSelected = true;
                    }
                    else
                    {
                        userRolesViewModel.IsSelected = false;
                    }
                    model.Add(userRolesViewModel);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task AddRemoveUserInRole(List<UserRolesViewModel> model, ApplicationUser user)
        {
            for (int i = 0; i < model.Count; i++)
            {
                var role = await _roleManager.FindByIdAsync(model[i].RoleId);
                IdentityResult result = null;

                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
            }
        }
        /* -------------------------------------   User/Claim Part  -----------------------------------*/
        public async Task<UserClaimsViewModel> GetClaimsofUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var ExistingClaims = await _userManager.GetClaimsAsync(user);
                var model = new UserClaimsViewModel
                {
                    UserId = userId
                };
                foreach (Claim claim in ClaimStore.AllClaims)
                {
                    UserClaim userClaim = new UserClaim
                    {
                        ClaimType = claim.Type
                    };

                    if (ExistingClaims.Any(c => c.Type == claim.Type))
                    {
                        userClaim.IsSelected = true;
                    }

                    model.Claims.Add(userClaim);

                }
                return model;
            }
            else
            {
                return null;
            }

        }

        public async Task<IdentityResult> RemoveClaims(ApplicationUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            return result;
        }

        public async Task<IdentityResult> AddRemoveUserInClaim(ApplicationUser user, UserClaimsViewModel model)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.AddClaimsAsync(user, model.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));
            return result;
        }
    }
}
