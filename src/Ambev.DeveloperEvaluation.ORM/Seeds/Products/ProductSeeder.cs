using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.ORM.Seeds.Products
{
    /// <summary>
    /// This class is responsible for seeding the database with product data.
    /// </summary>
    /// <param name="context"></param>
    public class ProductSeeder(DefaultContext context) : IProductSeeder
    {
        /// <summary>
        /// Runs the seeding process to add a default product to the database.
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            var products = GenerateFakeProducts(1);
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Runs the seeding process to add a specified number of products to the database.
        /// </summary>
        /// <param name="numberOfProducts">Products number to be seeded</param>
        /// <returns></returns>
        public async Task SeedAsync(int numberOfProducts)
        {
            if (!context.Products.Any())
            {
                var products = GenerateFakeProducts(numberOfProducts);
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Creates a list of fake products using Bogus library.
        /// </summary>
        /// <param name="count">Products count to be created</param>
        /// <returns><see cref="List{Product}"/></returns>
        private static List<Product> GenerateFakeProducts(int count = 20)
        {
            var faker = new Faker<Product>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(1, 1000)))
                .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
                .RuleFor(p => p.Quantity, f => f.Random.Int(0, 100))
                .RuleFor(p => p.CreatedAt, f => DateTime.UtcNow)
                .RuleFor(p => p.IsActive, true);

            var products = faker.Generate(count);
            return products;
        }
    }
}
