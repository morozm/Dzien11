using P06Shop.Shared;
using P06Shop.Shared.Shop;

namespace P06Shop.Shared.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<Book>>> GetBooksAsync();
        Task<ServiceResponse<List<Book>>> PostBookAsync();
        Task<ServiceResponse<List<Book>>> PutBookAsync();
        Task<ServiceResponse<List<Book>>> DeleteBookAsync();
    }
}
