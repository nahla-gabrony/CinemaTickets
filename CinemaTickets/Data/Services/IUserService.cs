using CinemaTickets.Data.Repository;
using CinemaTickets.Data.ViewModels.User;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IUserService
    {
        int Count();
        string GetUserId();
         bool IsAuthenticated();
        Task<ApplicationUser> GetById(string id);
        Task<IdentityResult> Delete(ApplicationUser user);
        Task<UserViewModel> CheckExistingUser(string id);
        Task<IdentityResult> UpdateUserById(UserViewModel model, ApplicationUser user);
        PagedResult<ApplicationUser> GetUserByPages(int page, string search = "");

        /* -------------------------------------   User/Role Part  -----------------------------------*/
        Task<List<UserRolesViewModel>> GetRolesofUser(ApplicationUser user);
        Task AddRemoveUserInRole(List<UserRolesViewModel> model, ApplicationUser user);
        Task<UserClaimsViewModel> GetClaimsofUser(string userId);
        Task<IdentityResult> RemoveClaims(ApplicationUser user);
        Task<IdentityResult> AddRemoveUserInClaim(ApplicationUser user, UserClaimsViewModel model);
      
    }
}