using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Database.Entities
{
    public class RequestType : BaseEntity
    {
        [Key]
        public int RequestID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
