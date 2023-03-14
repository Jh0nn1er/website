using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Database.Entities
{
    public class RequestFiles : BaseEntity
    {
        public int? RequestId { get; set; } 
        public virtual Request Request { get; set; }
        [MaxLength(2048)]
        public string FileURL { get; set; }
    }
}
