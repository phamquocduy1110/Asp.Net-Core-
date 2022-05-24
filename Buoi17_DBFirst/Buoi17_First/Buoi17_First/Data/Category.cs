namespace Buoi17_First.Data
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? Image { get; set; }

        public ICollection<Product>? Products { get; set; }
        public Category()
        {
            Products = new HashSet<Product>();
        }
    }
}
