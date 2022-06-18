namespace ECommerce.API.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public int CartId { get; set; }
        public int VegetableId { get; set; }

        public virtual Vegetable Vegetable { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
