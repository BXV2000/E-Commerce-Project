namespace ECommerce.API.DTOs
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public int VegetableId { get; set; }
        public string ImageURL { get; set; }
        public bool IsDeleted { get; set; }


    }
}
