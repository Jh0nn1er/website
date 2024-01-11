using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.API.v1.Authenticate.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
