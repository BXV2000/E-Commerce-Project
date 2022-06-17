namespace ECommerce.API.Models
{
    public class Vegetable
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime MFGDate { get; set; }
        public DateTime EXPDate { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }

        public virtual List<Image>? Images { get; set; } = new List<Image>();
        //public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
