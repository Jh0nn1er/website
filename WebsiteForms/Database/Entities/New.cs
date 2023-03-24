namespace WebsiteForms.Database.Entities
{
    public class New : BaseEntity
    {
        public string newTitle { get; set; }
        public string newDescription { get; set; }
        public string newUrl { get; set; }
        public DateTime newDate { get; set; }
        public bool newState { get; set; }
    }
}
