using P06Shop.Shared;
using P06Shop.Shared.Services.BookService;
using P06Shop.Shared.Shop;
using P07Shop.DataSeeder;

namespace P05Shop.API.Services.BookService
{
    public class BookService : IBookService
    {
        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = BookSeeder.GenerateBookData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new  ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<Book>>> PostBookAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = BookSeeder.Generate1BookData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<Book>>> PutBookAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = BookSeeder.Generate1BookData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<List<Book>>> DeleteBookAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = BookSeeder.Generate1BookData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
        }
    }
}
