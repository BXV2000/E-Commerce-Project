namespace ECommerce.API.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VegetableId { get; set; }
        public double RatingNumber { get; set; }

        //public virtual Vegetable Vegetable { get; set; }
        public virtual List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
