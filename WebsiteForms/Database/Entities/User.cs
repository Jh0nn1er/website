using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebsiteForms.Database.Entities
{
    public class User : BaseEntity
    {

        [Required, MaxLength(30), Index(IsUnique = true)]
        public string Username { get; set; }

        [Required, JsonIgnore]
        public string Password { get; set; }
    }
}
