using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Category;
using ClientLibrary.Models.Product;
using static ClientLibrary.Helper.Constant;

namespace ClientLibrary.Services;

public class CategoryService
    (IHttpClientHelper httpClient,IApiCallHelper apiCallHelper) 
    : ICategoryService
{
    //private
    public async Task<ServiceResponse> AddAsync(CreateCategory category)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Category.Add,
            Type = Constant.ApiCallType.Post,
            Client = client,
            Id = null,
            Model = category
        };
        var result = await apiCallHelper.ApiCallType<CreateCategory>(apiCall);
        return result == null ? apiCallHelper.ConnectionError() 
            : await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
    }
    //private
    public  async Task<ServiceResponse> DeleteAsync(Guid id)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Category.Delete,
            Type = Constant.ApiCallType.Delete,
            Client = client,
            Model = null!
        };
        apiCall.ToString(id);

        var result = await apiCallHelper.ApiCallType<Dummy>(apiCall);
        return result == null ? apiCallHelper.ConnectionError()
            : await apiCallHelper.GetServiceResponse<ServiceResponse>(result);

    }

    //private
    public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Category.Update,
            Type = Constant.ApiCallType.Update,
            Client = client,
            Id = null!,
            Model = category
        };
        var result = await apiCallHelper.ApiCallType<UpdateCategory>(apiCall);
        return result == null ? apiCallHelper.ConnectionError()
            : await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
    }
    public async Task<IEnumerable<GetCategory>> GetAllAsync()
    {
        var client =  httpClient.GetPublicClient();
        var apiCall = new ApiCall
        {
            Route = Constant.Category.Get,
            Type = Constant.ApiCallType.Get,
            Client = client,
            Id = null!,
            Model = null!
        };

        var result = await apiCallHelper.ApiCallType<Dummy>(apiCall);
        return result == null ? [] 
            : await apiCallHelper.GetServiceResponse<IEnumerable<GetCategory>>(result);
    }

    public async Task<GetCategory> GetByIdAsync(Guid id)
    {
        var client = httpClient.GetPublicClient();
        var apiCall = new ApiCall
        {
            Route = Constant.Category.Get,
            Type = Constant.ApiCallType.Get,
            Client = client,
            Id = null!,
            Model = null!
        };
        apiCall.ToString(id);

        var result = await apiCallHelper.ApiCallType<Dummy>(apiCall);
        return result == null ? null! 
            : await apiCallHelper.GetServiceResponse<GetCategory>(result);
    }

    public async Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId)
    {
        var client = httpClient.GetPublicClient();
        var apiCall = new ApiCall
        {
            Route = Constant.Category.Get,
            Type = Constant.ApiCallType.Get,
            Client = client,
            Model = null!
        };
        apiCall.ToString(categoryId);

        var result = await apiCallHelper.ApiCallType<Dummy>(apiCall);
        return result == null ? []
            : await apiCallHelper.GetServiceResponse<IEnumerable<GetProduct>>(result);
    }
}
