namespace server.Repository
{
    public interface IProductRepository
    {
        public class IProductRepository
        {
            Task<List<Product>> GetAllProducts();
            Task<bool> AddProduct(Product product);
            Task<bool> DeleteProductById(int productId);
        }
    }
}
