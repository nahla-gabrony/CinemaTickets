using CinemaTickets.Data.ViewModels.Role;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTickets.Data.Services
{
    public class RoleService :IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager,
                                        UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public  int Count()
        {
            return  _roleManager.Roles.Count();
        }
        public async Task<IdentityResult> CreateNewRole(CreateRoleViewModel model)
        {
            IdentityRole role = new IdentityRole()
            {
                Name = model.RoleName
            };
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> UpdateRoleById(RoleViewModel model , IdentityRole role)
        {
            role.Name = model.RoleName;
            return  await _roleManager.UpdateAsync(role);
        }

        public async Task<RoleViewModel> CheckExistingRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                var model = new RoleViewModel
                {
                    Id = role.Id,
                    RoleName = role.Name
                };
                foreach (var user in _userManager.Users.ToList())
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        model.Users.Add(user.UserName);
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<UsersRoleViewModel>> CheckUserInRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role != null)
            {
                var model = new List<UsersRoleViewModel>();
 
                foreach (var user in _userManager.Users.ToList())
                {
                    var userRoleViewModel = new UsersRoleViewModel
                    {
                        UserId = user.Id,
                        UserName = user.UserName
                    };
                    
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRoleViewModel.IsSelected = true;
                    }
                    else
                    {
                        userRoleViewModel.IsSelected = false;
                    }
                    model.Add(userRoleViewModel);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task AddRemoveUserInRole(List<UsersRoleViewModel> model, IdentityRole role)
        {
            for (int i = 0; i < model.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);
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
    }
}