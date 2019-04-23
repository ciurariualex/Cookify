using Core.Domain.Definition;
using Core.Domain.Models.Implementation;

namespace Core.Models
{
    public class AppUser : StableEntity, IDeletable
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
