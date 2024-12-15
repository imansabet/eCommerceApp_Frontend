
using NetcodeHub.Packages.WebAssembly.Storage.Cookie;

namespace ClientLibrary.Helper;

public class TokenService(IBrowserCookieStorageService cookieService ) : ITokenService
{
    public string FormToken(string jwt, string refresh)
    {
        return $"{jwt}--{refresh}";
    }

    public async Task<string> GetJWTTokenAsync(string key)
    {
        return await GetTokenAsync(key, 0);
    }
    public async Task<string> GetTokenAsync(string key , int position)
    {
        try 
        {
           string token  = await cookieService.GetAsync(key);
           return token != null ? token.Split("--")[position] : null!;
        }
        catch (Exception ex) 
        {
            return null!;
        }
    }

    public async Task<string> GetRefreshTokenAsync(string key)
    {
        return await GetTokenAsync(key, 1);

    }

    public async Task RemoveCookie(string key)
    {
        await cookieService.RemoveAsync(key);
    }

    public async Task SetCookie(string key, string value, int days, string path)
    {
        await cookieService.SetAsync(key, value, days, path);
    }
}
