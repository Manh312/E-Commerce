﻿namespace server.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public string ImageNameExt { get; set; }
        public ProductCategories ProductCategories { get; set; }
        public Brand Brand { get; set; }
        public Product Product { get; set; }
    }
}
