using ECommerce.API.Models.Enums;
using System.Text.Json.Serialization;

namespace ECommerce.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public int CartId { get; set; }
        public int Phone { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
