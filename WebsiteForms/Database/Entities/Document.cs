namespace WebsiteForms.Database.Entities
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public int InformationGroupId { get; set; }
        public virtual InformationGroup InformationGroup { get; set; }
    }
}
