namespace HackerNewsMAUISemple.Firebase.Models
{
    public class GetItemModel : BaseResponse
    {
        public ItemSource Item { get; set; }
    }

    public class ItemSource
    {
        public string by { get; set; }
        public int descendants { get; set; }
        public int id { get; set; }
        public IEnumerable<long> kids { get; set; }
        public IEnumerable<long> parts { get; set; }
        public int score { get; set; }
        public string text { get; set; }
        public int time { get; set; }
        public string Date
        {
            get { return UnixTimeStampToDateTime(time).ToString("yyyy-MM-dd HH:mm:ss"); }
        }
        public int KidsCount
        {
            get 
            {
                if (kids != null)
                    return kids.Count();

                return 0;
            }
        }
        public string title { get; set; }
        public string type { get; set; }
        public string url { get; set; }

        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
