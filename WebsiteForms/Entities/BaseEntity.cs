using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Entities
{
    public abstract class BaseEntity
    {
        private DateTime? _createdAt = null;

        [Required]
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
