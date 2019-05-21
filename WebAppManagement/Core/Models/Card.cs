namespace Core.Models
{
    using Core.Models.Base;
    using Core.Models.Enums;
    using System;

    public class Card : BaseEntity<Guid>
    {
        public Guid MobileApplicationUserId { get; set; }

        public string Image { get; set; }
        public string Name { get; set; }
        public string RestaurantName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }
        public bool HomeDeliveries { get; set; }

        public MobileApplicationUser MobileApplicationUser { get; set; }
    }
}
