using CinemaTickets.Data.Repository;
using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.User;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTickets.Areas.Admin.Controllers
{
    [Authorize(Policy  = "SuperManager")]
    [Route("admin")]
    [Area("admin")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {

            _userService = userService;
        }

        [Route("User-Index")]
        public IActionResult Index(int page = 1) 
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var users = _userService.GetUserByPages(page, "@cinematickets.com");
            return View(users);
        }

        [Route("User-Index")]
        [HttpPost]
        public IActionResult Index(string search, int page = 1)
        {
            ViewBag.EditSuccess = TempData["EditSuccess"];
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            ViewData["SearchString"] = search;
            PagedResult<ApplicationUser> users = null;
            if (search == "Employee")
            {
                 users = _userService.GetUserByPages(page, "@cinematickets.com");
            }
            else if (search == "All")
            {
                users = _userService.GetUserByPages(page);
            }
            else
            {
                users = _userService.GetUserByPages(page, search);
            }
            return View(users);
        }

        [Route("User-Details")]
        public async Task<IActionResult> Details(string userId)
        {
            var user = await _userService.CheckExistingUser(userId);
            if (user == null)
            {
                return View("NotFound");
            }
            return View(user);
        }

        [Route("Edit-User")]
        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userService.CheckExistingUser(userId);
            if (user == null)
            {
                return View("NotFound");
            }
            ViewBag.EditUserRoleSuccess = TempData["EditUserRoleSuccess"];
            ViewBag.EditUserClaimSuccess = TempData["EditUserClaimSuccess"];
            return View(user);
        }

        [Route("Edit-User")]
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            var user = await _userService.GetById(model.UserId);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                var result = await _userService.UpdateUserById(model, user);
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


        [Route("Delete-User")]
        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
               var result = await _userService.Delete(user);
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

        [Route("User-Roles")]
        [HttpGet]
        public async Task<IActionResult> ManageUserRole(string userId)
        {
            ViewData["userId"] = userId;
            var user = await _userService.GetById(userId);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                var model = await _userService.GetRolesofUser(user) ;
                return View(model);
            }
        }

        [Route("User-Roles")]
        [HttpPost]
        public async Task<IActionResult> ManageUserRole(List<UserRolesViewModel> model, string userId)
        {

            var user = await _userService.GetById(userId);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["EditUserRoleSuccess"] = true;
                await _userService.AddRemoveUserInRole(model, user);
                return RedirectToAction("Edit", new { userId = userId });
            }
        }
        /* -------------------------------------   User/Claim Part  -----------------------------------*/

        [Route("User-Claims")]
        [HttpGet]
        public async Task<IActionResult> ManageUserClaim(string userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                var model = await _userService.GetClaimsofUser(userId);
                return View(model);
            }
        }

        [Route("User-Claims")]
        [HttpPost]
        public async Task<IActionResult> ManageUserClaim(UserClaimsViewModel model)
        {

            var user = await _userService.GetById(model.UserId);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["EditUserClaimSuccess"] = true;
               var result =  await _userService.RemoveClaims(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user existing claims");
                    return View(model);
                }
                result = await _userService.AddRemoveUserInClaim(user,model);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected calims to user");
                    return View(model);
                }
                return RedirectToAction("Edit", new { userId = model.UserId });
            }
        }
    }
}
