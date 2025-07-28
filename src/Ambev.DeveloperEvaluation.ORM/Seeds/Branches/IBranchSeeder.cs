namespace Ambev.DeveloperEvaluation.ORM.Seeds.Branches
{
    public interface IBranchSeeder
    {
        /// <summary>
        /// Seeds the branchs into the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SeedAsync();
        /// <summary>
        /// Seeds the branchs into the database with a specified number of branchs.
        /// </summary>
        /// <param name="numberOfBranches">The number of branchs to seed.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SeedAsync(int numberOfBranches);
    }
}
