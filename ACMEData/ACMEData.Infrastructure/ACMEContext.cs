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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var products = new Product[]
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Leaf Rake",
                    ProductCode = "GDN-0011",
                    ReleaseData = "March 19, 2021",
                    Description = "Leaf rake with 48-inch wooden handle.",
                    Price = 19.95,
                    StarRating = 3.2
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Garden Cart",
                    ProductCode = "GDN-0023",
                    ReleaseData = "March 18, 2021",
                    Description = "15 gallon capacity rolling garden cart",
                    Price = 32.99,
                    StarRating = 4.2
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Hammer",
                    ProductCode = "TBX-0048",
                    ReleaseData = "May 21, 2021",
                    Description = "Curved claw steel hammer",
                    Price = 8.9,
                    StarRating = 4.8
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Saw",
                    ProductCode = "TBX-0022",
                    ReleaseData = "May 15, 2021",
                    Description = "15-inch steel blade hand saw",
                    Price = 11.55,
                    StarRating = 3.7
                },
                new Product
                {
                    ProductId = 10,
                    ProductName = "Video Game Controller",
                    ProductCode = "GMG-0042",
                    ReleaseData = "October 15, 2020",
                    Description = "Standard two-button video game controller",
                    Price = 35.95,
                    StarRating = 4.6
                }
            };

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}