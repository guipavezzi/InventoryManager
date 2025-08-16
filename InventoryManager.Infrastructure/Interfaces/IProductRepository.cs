public interface IProductRepository
{
    Task<Product> Add(Product entity);
    Task<Product> GetById(Guid id);
    Task<List<Product>> GetByIds(List<Guid> ids);
    Task<Product> Update(Product entity);
    Task<IList<Product>> Update(IList<Product> entity);
}