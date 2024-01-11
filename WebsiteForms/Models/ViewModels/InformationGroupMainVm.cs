namespace WebsiteForms.Models.ViewModels
{
    public class InformationGroupMainVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DocumentVm> Documents { get; set; }
    }
}
