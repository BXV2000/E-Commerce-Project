namespace ECommerce.API.Models
{
    public class Vegetable
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime MFGDate { get; set; }
        public DateTime EXPDate { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Image> Images { get; set; } = new List<Image>();
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
