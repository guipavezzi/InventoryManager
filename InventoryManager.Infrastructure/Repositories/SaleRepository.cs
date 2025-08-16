
public class SaleRepository : ISaleRepository
{
    private readonly ContextDB _context;
    public SaleRepository(ContextDB context)
    {
        _context = context;
    }
    public async Task<Sale> Add(Sale entity)
    {
        await _context.Sales.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}