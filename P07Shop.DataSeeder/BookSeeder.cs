using Bogus;
using P06Shop.Shared.Shop;

namespace P07Shop.DataSeeder
{
    public class BookSeeder
    {
        public static List<Book> GenerateBookData()
        {
            int bookId = 1;
            var bookFaker = new Faker<Book>()
                .RuleFor(x => x.Id, x => bookId++)
                .RuleFor(x => x.Title, x => x.Commerce.ProductName())
                .RuleFor(x => x.Author, x => x.Name.FullName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.Publisher, x => x.Commerce.ProductAdjective())
                .RuleFor(x => x.Rate, x => x.Random.Int(1, 10))
                .RuleFor(x => x.Genre, x => x.Commerce.ProductMaterial())
                .RuleFor(x => x.DateRead, x => x.Date.Recent())
                .RuleFor(x => x.DateAdded, x => x.Date.Recent());
            return bookFaker.Generate(10).ToList();
        }

        public static List<Book> Generate1BookData()
        {
            int bookId = 1;
            var bookFaker = new Faker<Book>()
                .RuleFor(x => x.Id, x => bookId++)
                .RuleFor(x => x.Title, x => x.Commerce.ProductName())
                .RuleFor(x => x.Author, x => x.Name.FullName())
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .RuleFor(x => x.Publisher, x => x.Commerce.ProductAdjective())
                .RuleFor(x => x.Rate, x => x.Random.Int(1, 10))
                .RuleFor(x => x.Genre, x => x.Commerce.ProductMaterial())
                .RuleFor(x => x.DateRead, x => x.Date.Recent())
                .RuleFor(x => x.DateAdded, x => x.Date.Recent());
            return bookFaker.Generate(1).ToList();
        }
    }
}