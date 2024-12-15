namespace ClientLibrary.Helper;

public interface ITokenService
{
    Task<string> GetJWTTokenAsync(string key);
    Task<string> GetRefreshTokenAsync(string key);
    string FormToken(string jwt, string refresh);
    Task SetCookie(string key, string value, int days, string path);
    Task RemoveCookie(string key);

}
