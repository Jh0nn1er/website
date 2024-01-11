namespace WebsiteForms.Database.Entities
{
    public class Configuration : BaseEntity
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
