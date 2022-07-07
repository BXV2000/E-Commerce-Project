using System.ComponentModel.DataAnnotations;

namespace ECommerce.SharedDataModels.Authenticate
{
    public class AuthenticateRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
