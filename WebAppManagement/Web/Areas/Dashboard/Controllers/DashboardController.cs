using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Dashboard.Models;

namespace Web.Area.Dashboard.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        protected readonly IMobileApplicationUserService mobileApplicationUserService;

        public DashboardController(
          IMobileApplicationUserService mobileApplicationUserService)
        {
            this.mobileApplicationUserService = mobileApplicationUserService;
        }

        public async Task<IActionResult> Index()
        {
            var mobileApplicationUsers = await mobileApplicationUserService.GetAllAsync();

            var model = new DashboardViewModel
            {
                MobileApplicationUsersCount = mobileApplicationUsers.Count,
            };

            return View("~/Areas/Dashboard/Views/Dashboard/Index.cshtml",model);
        }
    }
}