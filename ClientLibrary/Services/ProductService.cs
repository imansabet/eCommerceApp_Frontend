using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Product;
using ClientLibrary.Models.Product;
using static ClientLibrary.Helper.Constant;

namespace ClientLibrary.Services;

public class ProductService
    (IHttpClientHelper httpClient,IApiCallHelper apiCallHelper) 
    : IProductService
{
    //private
    public async Task<ServiceResponse> AddAsync(CreateProduct product)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Product.Add,
            Type = Constant.ApiCallType.Post,
            Client = client,
            Id = null,
            Model = product
        };
        var result = await apiCallHelper.ApiCallType<CreateProduct>(apiCall);
        return result == null ? apiCallHelper.ConnectionError() 
            : await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
    }
    //private
    public  async Task<ServiceResponse> DeleteAsync(Guid id)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Product.Delete,
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
    public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
    {
        var client = await httpClient.GetPrivateClientAsync();
        var apiCall = new ApiCall
        {
            Route = Constant.Product.Update,
            Type = Constant.ApiCallType.Update,
            Client = client,
            Id = null!,
            Model = product
        };
        var result = await apiCallHelper.ApiCallType<UpdateProduct>(apiCall);
        return result == null ? apiCallHelper.ConnectionError()
            : await apiCallHelper.GetServiceResponse<ServiceResponse>(result);
    }
    public async Task<IEnumerable<GetProduct>> GetAllAsync()
    {
        var client =  httpClient.GetPublicClient();
        var apiCall = new ApiCall
        {
            Route = Constant.Product.Get,
            Type = Constant.ApiCallType.Get,
            Client = client,
            Id = null!,
            Model = null!
        };

        var result = await apiCallHelper.ApiCallType<Dummy>(apiCall);
        return result == null ? [] 
            : await apiCallHelper.GetServiceResponse<IEnumerable<GetProduct>>(result);
    }

    public async Task<GetProduct> GetByIdAsync(Guid id)
    {
        var client = httpClient.GetPublicClient();
        var apiCall = new ApiCall
        {
            Route = Constant.Product.Get,
            Type = Constant.ApiCallType.Get,
            Client = client,
            Id = null!,
            Model = null!
        };
        apiCall.ToString(id);

        var result = await apiCallHelper.ApiCallType<Dummy>(apiCall);
        return result == null ? null! 
            : await apiCallHelper.GetServiceResponse<GetProduct>(result);
    }
}
