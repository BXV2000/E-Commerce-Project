namespace ECommerce.API.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VegetableId { get; set; }
        public double RatingNumber { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Vegetable> Vegetables { get; set; } = new List<Vegetable>();
        public virtual List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
