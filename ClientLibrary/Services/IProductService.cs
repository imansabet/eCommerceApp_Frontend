using ClientLibrary.Models;
using ClientLibrary.Models.Product;

namespace ClientLibrary.Services;

public interface IProductService
{
    Task<IEnumerable<GetProduct>> GetAllAsync();
    Task<GetProduct> GetByIdAsync(Guid id);
    Task<ServiceResponse> AddAsync(CreateProduct product);
    Task<ServiceResponse> UpdateAsync(UpdateProduct product);
    Task<ServiceResponse> DeleteAsync(Guid id);
}
