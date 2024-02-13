namespace HackerNewsMAUISemple.Firebase.Models
{
    public class GetProfilesItemsModel : BaseResponse
    {
        public ProfilesItemsSource Source { get; set; }
    }

    public class ProfilesItemsSource
    {
        public IEnumerable<long> Items { get; set; }
        public IEnumerable<string> Profiles { get; set; }
    }
}
