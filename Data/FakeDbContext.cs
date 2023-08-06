using Microsoft.EntityFrameworkCore;

namespace chessAI.Models // Replace 'YourApp.Models' with the appropriate namespace for your project
{
    // This is a fake or minimal DbContext class
    // It doesn't interact with a database
    public class FakeDbContext : DbContext
    {
        // Constructor (you can keep it empty)
        public FakeDbContext(DbContextOptions<FakeDbContext> options) : base(options)
        {
        }

        // You can define DbSet properties here if needed,
        // but they won't be used in your scenario
        // Example:
        // public DbSet<SomeEntity> SomeEntities { get; set; }
    }
}


