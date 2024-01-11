using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Database.Entities
{
    public class HabeasData
    {
        public int Id { get; set; }
        public bool? DeleteOfComercialBases { get; set; }
        public bool? DeleteOfCampaignBases { get; set; }
        public bool? DeleteOfEventBases { get; set; }
        [MaxLength(10)]
        public string LandLine{ get; set; }
        [Required, MaxLength(8000)]
        public string Reason{ get; set; }
        [EmailAddress]
        public string? EmailNotification{ get; set; }
        [MaxLength(200)]
        public string? AddressNotification { get; set; }
        [MaxLength(15)]
        public string? CellPhoneNotification{ get; set; }
        public virtual Request Request { get; set; }
    }
}
