using ClientLibrary.Models;
using ClientLibrary.Models.Authentication;

namespace ClientLibrary.Services;

public interface IAuthenticationService
{
    Task<ServiceResponse> CreateUser(CreateUser user);
    Task<LoginResponse> LoginUser(LoginUser user);
    Task<LoginResponse> ReviveToken(string refreshToken);
}
