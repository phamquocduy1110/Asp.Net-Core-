using System.ComponentModel.DataAnnotations;

namespace Buoi17_First.Data
{
    public class Product
    {
        public Guid ProductId { get; set; }

        [Display(Name = "Product name")]
        public string? ProductName { get; set; }

        public string? Image { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        
        public ICollection<ProductPrice> ProductPrices { get; set; }
        public Product()
        {
            ProductPrices = new List<ProductPrice>();
        }
    }

    public class Size
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<ProductPrice> ProductPrices { get; set; }
        public Size()
        {
            ProductPrices = new List<ProductPrice>();
        }
    }

    public class BrandColor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ColorName { get; set; }
        public ICollection<ProductPrice> ProductPrices { get; set; }
        public BrandColor()
        {
            ProductPrices = new List<ProductPrice>();
        }
    }

    public class ProductPrice
    {
        public Guid ProductId { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public Product? Product { get; set; }
        public BrandColor? Color { get; set; }
        public Size? Size { get; set; }
    }
}
