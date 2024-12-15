namespace ClientLibrary.Helper;

public interface IHttpClientHelper
{
    HttpClient GetPublicClient();
    Task<HttpClient> GetPrivateClientAsync();

}
