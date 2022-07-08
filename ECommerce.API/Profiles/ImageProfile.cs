using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.API.Models;

namespace ECommerce.API.Profiles
{
    public class ImageProfile:Profile
    {
        public ImageProfile()
        {
            //Soure -> Destination
            CreateMap<Image, ImageDTO>();
            CreateMap<ImageDTO, Image>()
                .ForMember(dest => dest.Id, o => o.Ignore())
                .ForMember(dest => dest.IsDeleted, o => o.Ignore());
        }
    }
}
