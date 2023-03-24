namespace WebsiteForms.API.v1.Models.News
{
    public class PutNewReq
    {
        public int Id { get; set; }
        public string newTitle { get; set; }
        public string newDescription { get; set; }
        public string newUrl { get; set; }
        public DateTime newDate { get; set; }
        public bool newState { get; set; }
    }
}
