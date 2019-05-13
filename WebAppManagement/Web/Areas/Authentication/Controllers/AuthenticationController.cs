using AutoMapper;
using Core.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web.Areas.Authentication.Models;

namespace Web.Areas.Controllers.Authentication
{
    [Route("Authentication")]
    public class AuthenticationController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly SignInManager<ApplicationUser> _singinManager;

        public AuthenticationController(IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _singinManager = signInManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var model = new UserLoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View("~/Areas/Authentication/Views/Authentication/Login.cshtml", model);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginViewModel uniqueModelName)
        {
            if (ModelState.IsValid)
            {

                var result = await _singinManager
                    .PasswordSignInAsync(
                    uniqueModelName.UserName,
                    uniqueModelName.Password,
                    uniqueModelName.IsPersistent,
                    false);

                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(uniqueModelName.ReturnUrl))
                    {
                        return Redirect(uniqueModelName.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(uniqueModelName);
        }

        [HttpGet("Register")]
        [Authorize(AuthorisationPolicies.UserRegister)]
        public async Task<IActionResult> Register()
        {
            return View("~/Areas/Authentication/Views/Authentication/Register.cshtml", new UserRegisterViewModel());
        }

        [HttpPost("Register")]
        [Authorize(AuthorisationPolicies.UserRegister)]
        public async Task<IActionResult> Register(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = _mapper.Map<ApplicationUser>(viewModel);

                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    return Redirect(nameof(Index));
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _singinManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}