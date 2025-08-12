
public class ProductRepository : IProductRepository
{
    private readonly ContextDB _context;

    public ProductRepository(ContextDB context)
    {
        _context = context;
    }
    public async Task<Product> Register(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}