using ECommerce.API.Models.Enums;

namespace ECommerce.API.Models.Authenticate
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public int Phone { get; set; }
        public bool IsDeleted { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Role = user.Role;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Phone = user.Phone;
            AddressId = user.AddressId;
            IsDeleted = user.IsDeleted;
            Email = user.Email;
            Token = token;
        }
    }
}
