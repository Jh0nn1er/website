namespace WebsiteForms.API.v1.Models.News
{
    public class PostNewReq
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Url { get; set; }
    }
}
