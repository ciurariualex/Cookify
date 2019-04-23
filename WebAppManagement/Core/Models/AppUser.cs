using Core.Domain.Definition;
using Core.Domain.Models.Implementation;

namespace Core.Models
{
    public class AppUser : StableEntity, IDeletable
    {
        public UserType UserType { get; set; }
        public string UserTypeString { get; set; }
        public string PhoneNumber { get; set; }
        public string AuthToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RestaurantName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
