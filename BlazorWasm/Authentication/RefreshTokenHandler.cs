using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Services;

namespace BlazorWasm.Authentication;

public class RefreshTokenHandler
    (ITokenService tokenService 
    , IAuthenticationService authenticationService
    ,IHttpClientHelper httpClient
    ) : DelegatingHandler
{

    protected override async Task<HttpResponseMessage>
        SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        bool isPost = request.Method.Equals("POST");
        bool isPut = request.Method.Equals("PUT");
        bool isDelete = request.Method.Equals("DELETE");
        var result = await base.SendAsync(request, cancellationToken);
        if (isPost || isPut || isDelete) 
        {
            if (result.StatusCode != System.Net.HttpStatusCode.Unauthorized)
                return result;

            var refreshToken = await tokenService.GetRefreshTokenAsync(Constant.Cookie.Name);
            if(string.IsNullOrEmpty(refreshToken))
                return result;

            var loginResponse = await MakeApiCall(refreshToken);
            if(loginResponse == null)
                return result;

            await httpClient.GetPrivateClientAsync();
            return await base.SendAsync(request, cancellationToken);
        }   
        return result;
    }

    private async Task<LoginResponse> MakeApiCall(string refreshToken)
    {
        var result = await authenticationService.ReviveToken(refreshToken);
        if (result.Success) 
        {
            string cookieValue = tokenService.FormToken(result.Token, result.RefreshToken);
            await tokenService.RemoveCookie(Constant.Cookie.Name);
            await tokenService.SetCookie
                (Constant.Cookie.Name
                , cookieValue
                ,Constant.Cookie.Days
                ,Constant.Cookie.Path);
            return result;
        }
        return null!;
    }
}
