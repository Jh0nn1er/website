namespace WebsiteForms.Database.Entities
{
    public class New : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Url { get; set; }
        public bool State { get; set; }
    }
}
