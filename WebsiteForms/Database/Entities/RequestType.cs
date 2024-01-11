using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Database.Entities
{
    public class RequestType : BaseEntity
    {

        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
