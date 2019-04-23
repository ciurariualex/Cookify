using Core.Business.Models.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<JsonResult> Register(string userName, string token, string email, string address, string phoneNumber)
        {
            var appUsers = await _appUserModel.GetAllActive();

            var user = appUsers.FirstOrDefault(appUser => appUser.Equals(userName) && appUser.Token.Equals(token));

            if (user == null)
            {
                var appUser = new AppUser()
                {
                    UserName = userName,
                    Token = token,
                    Email = email,
                    Address = address,
                    PhoneNumber = phoneNumber
                };

                await _appUserModel.Create(appUser);

                return Json(StatusCodes.Status200OK);
            }

            return Json(StatusCodes.Status400BadRequest);
        }

        public async Task<JsonResult> Login(string userName, string token)
        {
            bool result = false;

            var appUsers = await _appUserModel.GetAllActive();

            var currentUser = appUsers.FirstOrDefault(appUser => appUser.Equals(userName) && appUser.Token.Equals(token));

            if (currentUser != null)
            {
                result = true;
            }

            return Json(result);
        }

        public async Task<JsonResult> ExistUser(string userName, string token)
        {
            bool result = false;

            var appUsers = await _appUserModel.GetAllActive();

            var currentUser = appUsers.FirstOrDefault(appUser => appUser.Equals(userName));

            if (currentUser != null)
            {
                result = true;
            }

            return Json(result);
        }
    }
}