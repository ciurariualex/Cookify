using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Business.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Home;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        protected readonly IUserRepository _userModel;
        protected readonly IAppUserRepository _appUserModel;

        public HomeController(
            IUserRepository userRepository,
            IAppUserRepository appUserRepository)
        {
            _userModel = userRepository;
            _appUserModel = appUserRepository;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Notification", "");

            var appUsers = _appUserModel.GetAllActive().Result;

            var model = new HomeViewModel(appUsers.Count());

            return View(model);
        }
    }
}