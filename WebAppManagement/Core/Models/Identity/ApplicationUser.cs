namespace Core.Models.Identity
{
    using Core.Models.Base;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser, IDeletable
    {
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsDeleted { get; set; }
    }
}
