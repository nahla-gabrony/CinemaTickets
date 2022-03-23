using CinemaTickets.Data.Services;
using CinemaTickets.Data.ViewModels.Account;
using CinemaTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IAccountService accountService,
                                  UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Sign(string returnUrl)
        {
            SignInorSignUpViewModel model = new SignInorSignUpViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogin = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignInorSignUpViewModel model)
        {
            model.SignUpCheck = true;
            if (ModelState.IsValid)
            {
                var result = await  _accountService.CreateAccount(model.SignUp);
                
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                  
                    return View("Sign",model);
                }
                ModelState.Clear();
                return RedirectToAction("ConfirmEmail" , new { email = model.SignUp.Email});
            }
            return View("Sign");
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInorSignUpViewModel model, string returnUrl)
        {
            model.SignUpCheck = false;
            if (ModelState.IsValid)
            {
                var result = await _accountService.PasswordSignIn(model.SignIn);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsNotAllowed)
                {
                    ViewBag.SignInSummary = "Not allowed to login";
                }
                else
                {
                    ViewBag.SignInSummary = "Invalid Email or Password";
                }
                
            }
            return View("Sign",model);
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOut();
             return RedirectToAction("Index", "Home");
        }

        [HttpGet("Change-Password")]
        public  IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("Change-Password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ChangeUserPassword(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
        {
            ConfirmEmailViewModel model = new ConfirmEmailViewModel
            {
                Email = email
            };
            if(!string.IsNullOrEmpty(uid)&& !string.IsNullOrEmpty(token))
            {
                token = token.Replace(" ", "+");
                var result =  await _accountService.ConfirmEmail(uid, token);
                if (result.Succeeded)
                {
                    model.IsVerified = true;
                }
            }
            return View(model);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model )
        {
            var user = await _accountService.GetUserByEmail(model.Email);
            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    model.IsVerified = true;
                    return View();
                }
                await _accountService.GenerateEmailConfirmationToken(user);
                ModelState.Clear();
                model.IsSend = true;
            }
            else
            {
                ModelState.AddModelError("", "There is somthing wrong");
            }
            return View(model);
        }


        [HttpGet("Forgot-Password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountService.GetUserByEmail(model.Email);
                if(user != null)
                {
                    await _accountService.GenerateForgotPasswordToken(user);
                }
                ModelState.Clear();
                model.IsSend = true;
            }
            return View(model);
        }

        [HttpGet("Reset-Password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel()
            {
                Token = token,
                UserId = uid
            };
            return View(model);
        }

        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(" ", "+");
                var result = await _accountService.ResetPassword(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ExternalSignIn(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalSignInCallBack", "Account",
                                          new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalSignInCallBack(string returnUrl=null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            SignInorSignUpViewModel model = new SignInorSignUpViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogin = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error From External Provider:{remoteError}");
                return View("Sign", model);
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if(info == null)
            {
                ModelState.AddModelError("", "Error loading External Login information");
                return View("Sign", model);
            }
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if(email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if(user == null)
                    {
                        user = new ApplicationUser
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                            FirstName = info.Principal.FindFirstValue(ClaimTypes.Email).Split('@')[0]
                        };
                        await _userManager.CreateAsync(user);
                    }
                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }
                return View("Error");
            }
        
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
