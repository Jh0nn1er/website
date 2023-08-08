namespace WebsiteForms.Database.Entities
{
    public class InformationGroup : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Document> Documents { get; set; }
        public int Order { get; set; }
        public int? ParentInformationGroupId { get; set; }
        public virtual InformationGroup ParentInformationGroup { get; set; }
        public virtual ICollection<InformationGroup> InformationGroups { get; set; }
    }
}
