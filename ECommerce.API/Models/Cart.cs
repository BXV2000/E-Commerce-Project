namespace ECommerce.API.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDeleted { get; set; }

        public virtual User Customer { get; set; }
        public virtual List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
