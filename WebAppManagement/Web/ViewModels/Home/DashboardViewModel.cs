namespace Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public HomeViewModel(int appUsersCount)
        {
            AppUsersCount = appUsersCount;
        }

        public int AppUsersCount { get; set; }
    }
}
