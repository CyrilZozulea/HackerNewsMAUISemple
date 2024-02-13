using HackerNewsMAUISemple.Firebase.Models;
using System.Text.Json;

namespace HackerNewsMAUISemple.Firebase
{
    public class FirebaseManager : IFirebaseManager
    {
        private HttpClient httpClient;

        public FirebaseManager()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://hacker-news.firebaseio.com/");
        }

        public async Task<GetItemModel> GetItem(long item)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"v0/item/{item}.json?print=pretty");
                string json = await response.Content.ReadAsStringAsync();

                var test = JsonSerializer.Deserialize<ItemSource>(json);

                return new GetItemModel
                {
                    ErrorCode = ErrorCode.OK,
                    ErrorMessage = string.Empty,
                    Item = JsonSerializer.Deserialize<ItemSource>(json)
                };
            }
            catch(Exception ex)
            {
                return new GetItemModel
                {
                    ErrorCode = ErrorCode.InternalError,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetUserModel> GetUser(string user)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"v0/user/{user}.json?print=pretty");
                string json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<GetUserModel>(json);
            }
            catch(Exception ex)
            {
                return new GetUserModel
                {
                    ErrorCode = ErrorCode.InternalError,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<GetItemsModel> GetItems(StoriesType storiesType)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"v0/{storiesType.ToString().ToLower()}.json?print=pretty");
                string json = await response.Content.ReadAsStringAsync();

                return new GetItemsModel
                {
                    ErrorCode = ErrorCode.OK,
                    ErrorMessage = string.Empty,
                    Items = JsonSerializer.Deserialize<long[]>(json)
                };
            }
            catch (Exception ex)
            {
                return new GetItemsModel
                {
                    ErrorCode = ErrorCode.InternalError,
                    ErrorMessage = ex.Message
                };
            }
        } 

        public async Task<GetProfilesItemsModel> GetProfileItemsChanges()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("v0/updates.json?print=pretty");
                string json = await response.Content.ReadAsStringAsync();

                return new GetProfilesItemsModel
                {
                    ErrorCode = ErrorCode.OK,
                    ErrorMessage = string.Empty,
                    Source = JsonSerializer.Deserialize<ProfilesItemsSource>(json)
                };
            }
            catch (Exception ex)
            {
                return new GetProfilesItemsModel
                {
                    ErrorCode = ErrorCode.InternalError,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
