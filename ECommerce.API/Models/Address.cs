namespace ECommerce.API.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string CustomerAdress { get; set; }
        public string City { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customer Customer { get; set; }
        //public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
