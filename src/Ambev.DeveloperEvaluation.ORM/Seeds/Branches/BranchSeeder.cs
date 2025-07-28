
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.ORM.Seeds.Branches
{
    public class BranchSeeder(DefaultContext context) : IBranchSeeder
    {
        public async Task SeedAsync()
        {
            var branches = GenerateFakeBranchs(1);
            await context.Branches.AddRangeAsync(branches);
            await context.SaveChangesAsync();
        }

        public async Task SeedAsync(int numberOfBranches)
        {
            if (!context.Branches.Any())
            {
                var branches = GenerateFakeBranchs(numberOfBranches);
                await context.Branches.AddRangeAsync(branches);
                await context.SaveChangesAsync();
            }
        }

        private static List<Branch> GenerateFakeBranchs(int count = 5)
        {
            var faker = new Faker<Branch>()
                .RuleFor(b => b.Id, f => Guid.NewGuid())
                .RuleFor(b => b.Name, f => f.Company.CompanyName());

            return faker.Generate(count);
        }
    }
}
