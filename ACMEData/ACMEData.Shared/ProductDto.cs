namespace ACMEData.Shared
{
    public class ProductDto
    {
        public int productId { get; set; }

        public string productName { get; set; }

        public string productCode { get; set; }

        public string releaseData { get; set; }

        public string description { get; set; }

        public double price { get; set; }

        public double starRating { get; set; }

        public string imageBase64 { get; set; }
    }
}