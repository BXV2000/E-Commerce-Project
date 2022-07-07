using ECommerce.API.DTOs;
using ECommerce.SharedDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.SharedDataModels
{
    public class UserDTO
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

    }
}
