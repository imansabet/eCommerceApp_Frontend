using ClientLibrary.Models;
using System.Net.Http.Json;

namespace ClientLibrary.Helper;

public class ApiCallHelper : IApiCallHelper
{
    public async Task<HttpResponseMessage> ApiCallType<TModel>(ApiCall apiCall)
    {
        try
        {
            switch (apiCall.Type)
            {
                case "post":
                    return await apiCall.Client!.PostAsJsonAsync(apiCall.Route, (TModel)apiCall.Model!);
                case "update":
                    return await apiCall.Client!.PutAsJsonAsync(apiCall.Route, (TModel)apiCall.Model!);
                case "delete":
                    return await apiCall.Client!.DeleteAsync($"{apiCall.Route}/{apiCall.Id}");
                case "get":
                    string idRoute = apiCall.Id != null ? $"/{apiCall.Id}" : null!;
                    return await apiCall.Client!.GetAsync($"{apiCall.Route}{idRoute}");
                default:
                    throw new Exception("Api Call type Not Specified");
            }
        }
        catch { return null!; }
        
    }

    public ServiceResponse ConnectionError()
    {
        return new ServiceResponse(Message: "Error Occured in Communicating to the Server ");
    }

    public async Task<TResponse> GetServiceResponse<TResponse>(HttpResponseMessage message)
    {
        var response =  await message.Content.ReadFromJsonAsync<TResponse>()!;
        return response!;
    }
}
