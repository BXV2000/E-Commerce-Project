namespace ECommerce.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        //public int CustomerAddressId { get; set; }
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Customer Customer { get; set; }
        //public virtual Address Address { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
