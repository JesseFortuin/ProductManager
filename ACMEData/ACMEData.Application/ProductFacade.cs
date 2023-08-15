using ACMEData.Infrastructure;
using ACMEData.Shared;

namespace ACMEData.Application
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository productRepository;

        public ProductFacade(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<ProductDto> GetProducts()
        {
            var products = productRepository.GetProducts();

            var productsDtos = new List<ProductDto>();

            foreach (var product in products)
            {
                var productDto = new ProductDto
                {
                    productId = product.ProductId,
                    productName = product.ProductName,
                    productCode = product.ProductCode,
                    releaseData = product.ReleaseData,
                    description = product.Description,
                    price = product.Price,
                    starRating = product.StarRating
                };

                productsDtos.Add(productDto);
            }

            return productsDtos;
        }
    }
}