using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebsiteForms.Helpers;

namespace WebsiteForms.API.v1.Models.Requests
{
    [RequestSizeLimit(11 * 1024 * 1024)]
    public class RequestRequest
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(25)]
        public string? DocumentType { get; set; }

        [MaxLength(13)]
        public string? Identifier { get; set; }

        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [MaxLength(10)]
        public string? Credit { get; set; }

        [MaxLength(50)]
        public string? ModificationType { get; set; }

        public int? Term { get; set; }

        public DateTime? NewPaymentDate { get; set; }

        [MaxLength(50)]
        public string? LossOccuranceType { get; set; }

        [MaxLength(50)]
        public string? VehicleChanges { get; set; }

        [MaxLength(6)]
        public string? LicensePlate { get; set; }

        public DateTime? PaymentDate { get; set; }

        [MaxLength(50)]
        public string? ProcedureType { get; set; }

        [MaxLength(50)]
        public string? PQRType { get; set; }

        [MaxLength(8000)]
        public string? Comment { get; set; }

        [Required]
        public int? RequestTypeId { get; set; }

        public bool? PersonalDataProcessingAuthorization { get; set; }

        [AllowExtensions(".pdf")]
        public IFormFile? File { get; set; }

        public short? Age { get; set; }

        [MaxLength(30)]
        public string? Position { get; set; }

        [MaxLength(30)]
        public string? LastAcademicLevel { get; set; }
        [MaxLength(50)]
        public string? EconomicActivity { get; set; }
        [MaxLength(15)]
        public string? SQRType { get; set; }
        public bool? DeleteOfComercialBases { get; set; }
        public bool? DeleteOfCampaignBases { get; set; }
        public bool? DeleteOfEventBases { get; set; }
        [MaxLength(10)]
        public string? LandLine { get; set; }
        [MaxLength(8000)]
        public string? Reason { get; set; }
        [EmailAddress]
        public string? EmailNotification { get; set; }
        [MaxLength(200)]
        public string? AddressNotification { get; set; }
        [MaxLength(15)]
        public string? CellPhoneNotification { get; set; }
    }
}
