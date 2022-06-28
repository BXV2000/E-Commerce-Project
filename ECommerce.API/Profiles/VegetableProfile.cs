using AutoMapper;
using ECommerce.API.Models;
using ECommerce.SharedDataModels;

namespace ECommerce.API.Profiles
{
    public class VegetableProfile : Profile
    {
        public VegetableProfile()
        {
            CreateMap<Vegetable, VegetableDTO>();
            CreateMap<VegetableDTO, Vegetable>()
                .ForMember(dest => dest.Id, o => o.Ignore())
                .ForMember(dest => dest.IsDeleted, o => o.Ignore());
        }
    }
}
