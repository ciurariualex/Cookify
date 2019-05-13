namespace Core.Models.Identity
{
    using System;

    public class AspNetRole
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}
