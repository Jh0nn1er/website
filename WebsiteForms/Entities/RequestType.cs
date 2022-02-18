using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Entities
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
