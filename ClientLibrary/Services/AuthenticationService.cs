using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Authentication;
using ClientLibrary.Models.Category;
using ClientLibrary.Models.Product;
using System.Web;
using static ClientLibrary.Helper.Constant;

namespace ClientLibrary.Services;

public class AuthenticationService
    (IApiCallHelper apiCallHelper , IHttpClientHelper httpClient) 
    : IAuthenticationService
{
    public async Task<ServiceResponse> CreateUser(CreateUser user)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Authentication.Register,
            Type = Constant.ApiCallType.Post,
            Client = client,
            Id = null,
            Model = user
        };
        var result = await apiCallHelper.ApiCallType<CreateUser>(apiCall);
        return result == null ? apiCallHelper.ConnectionError()
            : await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
    }

    public async Task<LoginResponse> LoginUser(LoginUser user)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Authentication.Login,
            Type = Constant.ApiCallType.Post,
            Client = client,
            Id = null,
            Model = user
        };
        var result = await apiCallHelper.ApiCallType<LoginUser>(apiCall);
        return result == null ? new LoginResponse(Message: apiCallHelper.ConnectionError().Message)
            : await apiCallHelper.GetServiceResponse<LoginResponse>(result);
    }

    public async Task<LoginResponse> ReviveToken(string refreshToken)
    {
        var client = httpClient.GetPublicClient();
        var apiCall = new ApiCall
        {
            Route = Constant.Authentication.ReviveToken,
            Type = Constant.ApiCallType.Get,
            Client = client,
            Id = HttpUtility.UrlEncode(refreshToken),
            Model = null!
        };

        var result = await apiCallHelper.ApiCallType<Dummy>(apiCall);
        return result == null ? null!
            : await apiCallHelper.GetServiceResponse<LoginResponse>(result);
    }
}
