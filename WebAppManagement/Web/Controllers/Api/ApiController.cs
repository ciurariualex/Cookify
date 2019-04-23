using Core.Business.Models.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers.Api
{
    public class ApiController : BaseController
    {
        protected readonly IAppUserRepository _appUserModel;

        public ApiController(IAppUserRepository appUserRepository)
        {
            _appUserModel = appUserRepository;
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register([FromBody]AppUser model)
        {
            var appUsers = await _appUserModel.GetAllActive();

            var user = appUsers.FirstOrDefault(appUser => appUser.Equals(model.AuthToken));

            if (user == null)
            {
                var appUser = new AppUser()
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

                await _appUserModel.Create(appUser);

                return this.Accepted(new { appUser.AuthToken, Message = "Successfully Created" });
            }

            return this.BadRequest("User exist");
        }

        public async Task<IActionResult> Login(string AuthToken)
        {
            var appUsers = await _appUserModel.GetAllActive();

            var currentUser = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(AuthToken));

            if (currentUser != null)
            {
                return this.Accepted(currentUser);
            }

            return this.BadRequest();
        }
    }
}