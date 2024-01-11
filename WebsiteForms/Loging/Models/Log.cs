namespace WebsiteForms.Loging.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string JsonData { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
