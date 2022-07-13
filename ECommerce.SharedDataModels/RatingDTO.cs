using ECommerce.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedDataModels
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int VegetableId { get; set; }
        public int RatingNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}
