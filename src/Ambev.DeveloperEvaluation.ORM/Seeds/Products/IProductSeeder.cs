namespace Ambev.DeveloperEvaluation.ORM.Seeds.Products
{
    /// <summary>
    /// This interface defines the contract for seeding products into the database.
    /// </summary>
    public interface IProductSeeder
    {
        /// <summary>
        /// Seeds the products into the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SeedAsync();
        /// <summary>
        /// Seeds the products into the database with a specified number of products.
        /// </summary>
        /// <param name="numberOfProducts">The number of products to seed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SeedAsync(int numberOfProducts);
    }
}
