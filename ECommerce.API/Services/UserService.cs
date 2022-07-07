using AutoMapper;
using ECommerce.API.Authorization;
using ECommerce.API.Data;
using ECommerce.API.Helpers;
using ECommerce.API.Models;
using ECommerce.API.Models.Enums;
using ECommerce.SharedDataModels;
using ECommerce.SharedDataModels.Authenticate;
using Microsoft.Extensions.Options;

namespace ECommerce.API.Services
{
    public interface IUserService
    {
        AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model);
        UserDTO Register(RegisterRequestDTO model);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(int id);
    }

    public class UserService : IUserService
    {
        private ECommerceDbContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserService(ECommerceDbContext context, IJwtUtils jwtUtils, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

                // Validate
                if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                    return null;

                var userDto = _mapper.Map<UserDTO>(user);

                // Authentication successful so generate jwt token
                var jwtToken = _jwtUtils.GenerateJwtToken(userDto);

                return new AuthenticateResponseDTO(userDto, jwtToken);
            }
            catch
            {
                return null;
            }
        }

        public UserDTO Register(RegisterRequestDTO model)
        {
            try
            {
                var userDto = _mapper.Map<UserDTO>(model);
                userDto.IsDeleted = false;
                userDto.Role = (SharedDataModels.Enums.UserRole)UserRole.Customer;
                userDto.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

                _context.Users.Add(_mapper.Map<User>(userDto));
                _context.SaveChanges();

                return userDto;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_context.Users);
        }

        public UserDTO GetById(int id)
        {
            var user = _context.Users.Find(id);
            var userDto = _mapper.Map<UserDTO>(user);
            if (userDto == null)
                throw new KeyNotFoundException("User not found");
            return userDto;
        }



    }
}
