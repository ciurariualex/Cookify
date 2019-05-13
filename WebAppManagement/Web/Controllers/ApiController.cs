using Core.Interfaces;
using Core.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ApiController : Controller
    {
        protected readonly IMobileApplicationUserService mobileApplicationUserService;

        public ApiController(
         IMobileApplicationUserService mobileApplicationUserService)
        {
            this.mobileApplicationUserService = mobileApplicationUserService;
        }

        public async Task<IActionResult> RegisterGet(Web.Models.MobileApplicationUserService model)
        {
            var appUsers = await mobileApplicationUserService.GetAllAsync();

            var user = appUsers.FirstOrDefault(appUser => appUser.Equals(model.AuthToken));

            if (user == null)
            {
                var mobileAppUser = new Core.Models.MobileApplicationUser()
                {
                    UserType = (UserType)Enum.Parse(typeof(UserType), model.UserTypeString),
                    AuthToken = model.AuthToken,
                    Email = model.Email,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    RestaurantName = model.RestaurantName,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    PhoneNumber = model.PhoneNumber
                };

                await mobileApplicationUserService.CreateAsync(mobileAppUser);

                return this.Accepted(new { mobileAppUser.AuthToken, Message = "Successfully Created" });
            }

            return this.BadRequest("User already exists");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPost([FromBody]Web.Models.MobileApplicationUserService model)
        {
            var appUsers = await mobileApplicationUserService.GetAllAsync();

            var user = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(model.AuthToken));

            if (user == null)
            {
                var appUser = new Core.Models.MobileApplicationUser()
                {
                    UserType = (UserType)Enum.Parse(typeof(UserType), model.UserTypeString),
                    AuthToken = model.AuthToken,
                    Email = model.Email,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    RestaurantName = model.RestaurantName,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    PhoneNumber = model.PhoneNumber
                };

                await mobileApplicationUserService.CreateAsync(appUser);

                return this.Accepted(new { appUser.AuthToken, Message = "Successfully Created" });
            }

            return this.BadRequest("User already exists");
        }

        public async Task<IActionResult> LoginGet(string AuthToken)
        {
            var appUsers = await mobileApplicationUserService.GetAllAsync();

            var currentUser = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(AuthToken));

            if (currentUser != null)
            {
                return this.Accepted(currentUser);
            }

            return this.BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost(string AuthToken)
        {
            var appUsers = await mobileApplicationUserService.GetAllAsync();

            var currentUser = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(AuthToken));

            if (currentUser != null)
            {
                return this.Accepted(currentUser);
            }

            return this.BadRequest();
        }
    }
}
