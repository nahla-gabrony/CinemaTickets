using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{
    [Authorize(Policy  = "SuperManager")]
    [Route("admin")]
    [Area("admin")]
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly RoleManager<IdentityRole> _roleManager;
      

        public RolesController(IRoleService roleService,
                                        RoleManager<IdentityRole> roleManager)
        {
            _roleService = roleService;
            _roleManager = roleManager;
        }

        /* -------------------------------------   Role Part  -----------------------------------*/
        [Route("Role-Index")]
        public IActionResult Index()
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var roles = _roleManager.Roles; 
            return View(roles);
        }

        [Route("Create-Role")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create-Role")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.CreateNewRole(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [Route("Role-Details")]
        public async Task<IActionResult> Details(string roleId)
        {
            var role = await _roleService.CheckExistingRole(roleId);
            if (role == null)
            {
                return View("NotFound");
            }
            return View(role);
        }

        [Route("Edit-Role")]
        [HttpGet]
        public async Task<IActionResult> Edit(string roleId)
        {
            var model = await _roleService.CheckExistingRole(roleId);
            if (model == null)
            {
                return View("NotFound");
            }
            ViewBag.EditUserRoleSuccess = TempData["EditUserRoleSuccess"];
            return View(model);
        }

        [Route("Edit-Role")]
        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                return View("NotFound");
            }
            else
            {
                var result = await _roleService.UpdateRoleById(model, role);
                if (result.Succeeded)
                {
                    TempData["EditSuccess"] = true;
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        [Route("Delete-Role")]
        [HttpPost]
        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return View("NotFound");
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    TempData["DeleteSuccess"] = true;
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction("Index");
            }
        }
        /* -------------------------------------   User/Role Part  -----------------------------------*/
        [Route("EditUsers-Role")]
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewData["roleId"] = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return View("NotFound");
            }
            else
            {
                var model = await _roleService.CheckUserInRole(roleId);
                return View(model);
            }

        }

        [Route("EditUsers-Role")]
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UsersRoleViewModel> model, string roleId)
        {

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["EditUserRoleSuccess"] = true;
                await _roleService.AddRemoveUserInRole(model, role);
                return RedirectToAction("Edit", new { roleId = roleId });
            }
        }

    }
}
