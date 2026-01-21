using order_api.Models;

namespace order_api.Services;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
}
