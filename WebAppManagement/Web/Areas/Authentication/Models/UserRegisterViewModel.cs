namespace Web.Areas.Authentication.Models
{
    using System;

    public class UserRegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
