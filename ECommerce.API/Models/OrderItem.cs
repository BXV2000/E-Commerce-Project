namespace ECommerce.API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public int OrderId { get; set; }
        public int VegetableId { get; set; }

        public virtual Vegetable Vegetable { get; set; }
        public virtual Order Order { get; set; }
    }
}
