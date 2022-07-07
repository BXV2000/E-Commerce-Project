using AutoMapper;
using ECommerce.API.Models;
using ECommerce.SharedDataModels;
using ECommerce.SharedDataModels.Authenticate;

namespace ECommerce.API.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RegisterRequestDTO, UserDTO>();
        }
    }
}
