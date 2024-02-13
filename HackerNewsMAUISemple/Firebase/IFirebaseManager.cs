using HackerNewsMAUISemple.Firebase.Models;

namespace HackerNewsMAUISemple.Firebase
{
    public interface IFirebaseManager
    {
        Task<GetItemModel> GetItem(long item);
        Task<GetUserModel> GetUser(string user);
        Task<GetItemsModel> GetItems(StoriesType storiesType);
        Task<GetProfilesItemsModel> GetProfileItemsChanges();
    }
}
