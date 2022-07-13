using AutoMapper;
using ECommerce.API.Models;
using ECommerce.SharedDataModels;

namespace ECommerce.API.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingDTO>();
            CreateMap<RatingDTO, Rating>()
                .ForMember(dest => dest.Id, o => o.Ignore())
                .ForMember(dest => dest.IsDeleted, o => o.Ignore());
        }
    }
}
