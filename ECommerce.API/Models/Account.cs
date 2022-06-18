using ECommerce.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEnabled { get; set; }
        public UserRole Role { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
