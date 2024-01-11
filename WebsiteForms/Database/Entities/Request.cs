using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Database.Entities
{
    public class Request : BaseEntity
    {

        [Required, MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(25)]
        public string DocumentType { get; set; }

        [MaxLength(13)]
        public string? Identifier { get; set; }

        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Credit { get; set; }

        [MaxLength(50)]
        public string ModificationType { get; set; }

        public int? Term { get; set; }

        public DateTime? NewPaymentDate { get; set; }

        [MaxLength(50)]
        public string LossOccuranceType { get; set; }

        [MaxLength(50)]
        public string VehicleChanges { get; set; }

        [MaxLength(6)]
        public string LicensePlate { get; set; }

        public DateTime? PaymentDate { get; set; }

        [MaxLength(50)]
        public string ProcedureType { get; set; }

        [MaxLength(50)]
        public string PQRType { get; set; }

        [MaxLength(8000)]
        public string Comment { get; set; }

        public bool? PersonalDataProcessingAuthorization { get; set; }
        
        public short? Age { get; set; }

        [MaxLength(30)]
        public string? Position { get; set; }

        [MaxLength(30)]
        public string? LastAcademicLevel { get; set; }
        [MaxLength(200)]
        public string? EconomicActivity { get; set; }
        [MaxLength(200)]
        public string? SQRType { get; set; }
        public virtual RequestType RequestType { get; set; }
        public string?  Address { get; set; }
    }
}
