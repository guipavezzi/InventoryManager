
public class ProductSaleRepository : IProductSaleRepository
{
    private readonly ContextDB _context;

    public ProductSaleRepository(ContextDB context)
    {
        _context = context;
    }
    public async Task<ProductSale> Add(ProductSale entity)
    {
        await _context.ProductSales.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}