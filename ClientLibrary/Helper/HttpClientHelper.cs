namespace ClientLibrary.Helper;

using System.Net.Http.Headers;

public class HttpClientHelper
    (IHttpClientFactory httpClientFactory , ITokenService tokenService) 
    : IHttpClientHelper
{
    public async Task<HttpClient> GetPrivateClientAsync()
    {
        var client =  httpClientFactory.CreateClient(Constant.ApiClient.Name);

        string token = await tokenService.GetJWTTokenAsync(Constant.Cookie.Name);
        if(string.IsNullOrEmpty(token))
            return client;
        
        var newClient = new HttpClient();

        newClient.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue(Constant.Authentication.Type, token);
        return newClient;
        
    
    }

    public HttpClient GetPublicClient()
    {
        return httpClientFactory.CreateClient(Constant.ApiClient.Name);
    }
}
