namespace ECommerce.API.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int VegetableId { get; set; }
        public string ImageURL { get; set; }

        public virtual Vegetable Vegetable { get; set; }
    }
}
