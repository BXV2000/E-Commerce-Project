using ECommerce.SharedDataModels;

namespace ECommerce.Customer.Models
{
    public class MultiModels
    {
        public List<CategoryDTO> Categories { get; set; }
        public CategoryDTO Category { get; set; }
        public List<VegetableDTO> Vegetables { get; set; }
    }
}
