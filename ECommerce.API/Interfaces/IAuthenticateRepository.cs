using ECommerce.API.Models;
using ECommerce.SharedDataModels;
using ECommerce.SharedDataModels.Authenticate;

namespace ECommerce.API.Interfaces
{
    public interface IAuthenticateService
    {
        AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model);
        UserDTO Register(RegisterRequestDTO model);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetById(int id);
    }
}
