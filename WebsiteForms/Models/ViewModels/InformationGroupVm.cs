namespace WebsiteForms.Models.ViewModels
{
    public class InformationGroupVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<InformationGroupVm> InformationGroups { get; set; }
        public List<DocumentVm> Documents { get; set; }
    }
}
