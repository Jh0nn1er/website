namespace WebsiteForms.API.v1.Models.News
{
    public class PostNewReq
    {
        public string newTitle { get; set; }
        public string newDescription { get; set; }
        public string newUrl { get; set; }
        public DateTime newDate { get; set; }
        public bool newState { get; set; }
    }
}
