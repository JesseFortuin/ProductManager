using System.ComponentModel.DataAnnotations;

namespace ACMEData.Domain
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public string ReleaseData { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public double StarRating { get; set; }
    }
}