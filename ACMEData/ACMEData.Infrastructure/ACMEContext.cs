using ACMEData.Domain;
using Microsoft.EntityFrameworkCore;


namespace ACMEData.Infrastructure
{
    public class ACMEContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ACMEContext()
        {
            
        }

        public ACMEContext(DbContextOptions<ACMEContext> contextOptions)
            : base(contextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ACME");
        }
    }
}