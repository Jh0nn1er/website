namespace WebsiteForms.API.v1.Models.News
{
    public class PutNewReq
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Url { get; set; }
        public bool State { get; set; }
    }
}
