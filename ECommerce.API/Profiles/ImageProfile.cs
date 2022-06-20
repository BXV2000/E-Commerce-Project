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
            CreateMap<ImageDTO, Image>().ReverseMap();
        }
    }
}
