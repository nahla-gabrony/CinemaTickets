using CinemaTickets.Data.ViewModels.Role;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public interface IRoleService
    {
        int Count();
        Task<IdentityResult> CreateNewRole(CreateRoleViewModel model);
        Task<IdentityResult> UpdateRoleById(RoleViewModel model, IdentityRole role);
        Task<RoleViewModel> CheckExistingRole(string id);
        Task<List<UsersRoleViewModel>> CheckUserInRole(string roleId);
        Task AddRemoveUserInRole(List<UsersRoleViewModel> model, IdentityRole role);
     
    }
}