using ACMEData.Domain;

namespace ACMEData.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ACMEContext context;

        public ProductRepository(ACMEContext context)
        {
            this.context = context;
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }
    }
}
