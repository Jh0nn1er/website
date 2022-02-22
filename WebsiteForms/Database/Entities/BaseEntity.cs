using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebsiteForms.Database.Entities
{
    public abstract class BaseEntity
    {
        private DateTime? _createdAt = null;

        [Key]
        public int Id { get; set; }

        [Required, JsonIgnore]
        public DateTime CreatedAt {
            get
            {
                return _createdAt.HasValue
                ? _createdAt.Value
                : DateTime.Now;
            }
            set { _createdAt = value; }
        }
    }
}
