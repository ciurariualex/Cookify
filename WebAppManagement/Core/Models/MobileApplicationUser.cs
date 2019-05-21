namespace Core.Models
{
    using Core.Models.Base;
    using Core.Models.Enums;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MobileApplicationUser : BaseEntity<Guid>
    {
        public UserType UserType { get; set; }
        public string PhoneNumber { get; set; }
        public string AuthToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string RestaurantName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool HomeDeliveries { get; set; }

        public IEnumerable<Card> Cards { get; set; }
    }
}
