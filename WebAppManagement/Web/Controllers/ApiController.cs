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
        protected readonly ICardService cardService;

        public ApiController(
         IMobileApplicationUserService mobileApplicationUserService,
         ICardService cardService)
        {
            this.mobileApplicationUserService = mobileApplicationUserService;
            this.cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]Web.Models.MobileApplicationUserService model)
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
                    PhoneNumber = model.PhoneNumber,
                    HomeDeliveries = model.HomeDeliveries
                };

                await mobileApplicationUserService.CreateAsync(appUser);

                return this.Accepted(new { appUser.AuthToken, Message = "Successfully Created" });
            }

            return this.BadRequest("User already exists");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string authToken)
        {
            var appUsers = await mobileApplicationUserService.GetAllAsync();

            var currentUser = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(authToken));

            if (currentUser != null)
            {
                return this.Accepted(currentUser);
            }

            return this.BadRequest("User not found");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string authToken)
        {
            var appUsers = await mobileApplicationUserService.GetEagerAllAsync();

            var currentUser = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(authToken));

            if (currentUser != null)
            {
                foreach (var card in currentUser.Cards)
                {
                    await cardService.DeleteAsync(card);
                }
                await mobileApplicationUserService.DeleteAsync(currentUser);
                return this.Accepted("User succesfully deleted");
            }

            return this.BadRequest("User not found");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCard(string cardId)
        {
            if (!Guid.TryParse(cardId, out var id))
            {
                return this.BadRequest("Invalid Id");
            }
            var card = await cardService.GetByIdAsync(id);

            if (card != null)
            {
                await cardService.DeleteAsync(card);
                return this.Accepted("Card succesfully deleted");
            }

            return this.BadRequest("Card not found");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCard([FromBody]Web.Models.Card model)
        {
            var cards = await cardService.GetAllAsync();

            var card = cards.FirstOrDefault(c => c.Id.Equals(model.cardId));

            if (card != null)
            { 
                card.Image = model.Image;
                card.Name = model.Name;
                card.Description = model.Description;
                card.Price = model.Price;
                card.Category = model.Category;

                await cardService.UpdateAsync(card);

                return this.Accepted(new { card.Id, Message = "Successfully Updated" });
            }

            return this.BadRequest("Card not found");
        }


        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody]Web.Models.Card model)
        {
            var appUsers = await mobileApplicationUserService.GetAllAsync();

            var user = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(model.AuthToken));

            if (user != null)
            {
                var card = new Core.Models.Card
                {
                    //MobileApplicationUser = user,
                    MobileApplicationUserId = user.Id,
                    RestaurantName = user.RestaurantName,
                    Latitude = user.Latitude,
                    Longitude = user.Longitude,
                    PhoneNumber = user.PhoneNumber,
                    HomeDeliveries = user.HomeDeliveries,
                    Name = model.Name,
                    Category = model.Category,
                    Description = model.Description,
                    Image = model.Image,
                    Price = model.Price,
                };

                await cardService.CreateAsync(card);

                return this.Accepted(new { card.Id, Message = "Card Successfully Added" });
            }

            return this.BadRequest("User not found");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserDetails(string authToken)
        {
            var appUsers = await mobileApplicationUserService.GetEagerAllAsync();

            var user = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(authToken));

            if (user != null)
            {
                return this.Accepted(user);
            }

            return this.BadRequest("User not found");
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurantCards(string authToken)
        {
            var appUsers = await mobileApplicationUserService.GetEagerAllAsync();

            var user = appUsers.FirstOrDefault(appUser => appUser.AuthToken.Equals(authToken));

            if (user != null && user.UserType == UserType.Restaurant)
            {
                return this.Accepted(user.Cards);
            }

            return this.BadRequest("Restaurant not found");
        }

        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var cards = await cardService.GetAllAsync();

            if (cards.Any())
            {
                return this.Accepted(cards);
            }

            return this.BadRequest("Cards not found");
        }

        [HttpGet]
        public IActionResult CheckConnection()
        {
            return this.Accepted("Success");
        }
    }
}