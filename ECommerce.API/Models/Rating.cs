namespace ECommerce.API.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int VegetableId { get; set; }
        public int RatingNumber { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Vegetable Vegetables { get; set; }
    }
}
