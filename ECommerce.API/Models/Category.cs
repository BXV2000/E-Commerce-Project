namespace ECommerce.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual List<Vegetable> Vegetables { get; set; } = new List<Vegetable>();
    }
}
