namespace ECommerce.API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public int CartId { get; set; }
        public int Phone { get; set; }
        public int AccountId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Address Address { get; set; }
        public virtual Account Account { get; set; }
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
