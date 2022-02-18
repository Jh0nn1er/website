using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Entities
{
    public class Request : BaseEntity
    {
        [Key]
        public int RequestId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(13)]
        public string Identifier { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Credit { get; set; }

        [MaxLength(50)]
        public string ModificationType { get; set; }

        public int? Term { get; set; }

        public DateTime NewPaymentDate { get; set; }

        [MaxLength(50)]
        public string LossOccuranceType { get; set; }

        [MaxLength(50)]
        public string VehicleChanges { get; set; }

        [MaxLength(6)]
        public string LicensePlate { get; set; }

        public DateTime PaymentDate { get; set; }

        [MaxLength(50)]
        public string ProcedureType { get; set; }

        [MaxLength(2048)]
        public string PolicyPDFURL { get; set; }

        [MaxLength(50)]
        public string PQRType { get; set; }

        [MaxLength(50)]
        public string PQRComment { get; set; }

        [Required]
        public int RequestTypeId { get; set; }
        public virtual RequestType RequestType { get; set; }
    }
}
