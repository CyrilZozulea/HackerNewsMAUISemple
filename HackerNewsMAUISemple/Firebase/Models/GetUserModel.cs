namespace HackerNewsMAUISemple.Firebase.Models
{
    public class GetUserModel : BaseResponse
    {
        public string About { get; set; }
        public int Created { get; set; }
        public int Delay { get; set; }
        public string ID { get; set; }
        public int Karma { get; set; }
        public IEnumerable<long> Submitted { get; set; }
    }
}
