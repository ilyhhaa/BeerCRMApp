using Microsoft.EntityFrameworkCore;

namespace MyBeerCRMApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Brewery> breweries { get; set; } = null!;

        public DbSet<Beer> beers { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
