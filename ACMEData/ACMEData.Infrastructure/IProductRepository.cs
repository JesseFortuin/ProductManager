using ACMEData.Domain;

namespace ACMEData.Infrastructure
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
    }
}