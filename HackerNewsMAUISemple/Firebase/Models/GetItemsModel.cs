namespace HackerNewsMAUISemple.Firebase.Models
{
    public class GetItemsModel : BaseResponse
    {
        public IEnumerable<long> Items { get; set; }
    }
}
