using ACMEData.Shared;

namespace ACMEData.Application
{
    public interface IProductFacade
    {
        public List<ProductDto> GetProducts();
    }
}