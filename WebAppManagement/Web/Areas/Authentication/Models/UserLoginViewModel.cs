namespace Web.Areas.Authentication.Models
{
    public class UserLoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool IsPersistent { get; set; }
    }
}
