using P06Shop.Shared;
using P06Shop.Shared.Shop;

namespace P05Shop.API.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
    }
}
