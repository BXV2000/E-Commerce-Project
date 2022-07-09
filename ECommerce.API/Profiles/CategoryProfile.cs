using AutoMapper;
using ECommerce.API.Models;
using ECommerce.SharedDataModels;

namespace ECommerce.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>()
                .ForMember(dest => dest.Id, o => o.Ignore())
                .ForMember(dest => dest.IsDeleted, o => o.Ignore())
                .ForMember(dest => dest.Vegetables, o => o.Ignore());
        }
    }
}
