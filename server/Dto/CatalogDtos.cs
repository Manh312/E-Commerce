namespace server.Dto
{
    public class CreateProductReq
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsFeatured { get; set; } = false;
        public int BrandId { get; set; }
        public int ProductCategoryId { get; set; }
        public IFormFile Thumbnail { get; set; }
    }

    public class  CreateBrandReq
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }

    public class CreateProductCategoriesReq
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}
