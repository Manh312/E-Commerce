namespace server.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }
        public bool InStock { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public ProductCategories ProductCategories { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }
    }
}
