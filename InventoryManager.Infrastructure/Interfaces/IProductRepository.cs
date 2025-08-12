public interface IProductRepository
{
    Task<Product> Register(Product entity);
}