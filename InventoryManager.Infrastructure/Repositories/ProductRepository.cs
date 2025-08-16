

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly ContextDB _context;

    public ProductRepository(ContextDB context)
    {
        _context = context;
    }
    public async Task<Product> Add(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>> GetByIds(List<Guid> ids)
    {
        return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
    }

    public async Task<Product> Update(Product entity)
    {
        _context.Products.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IList<Product>> Update(IList<Product> entity)
    {
        _context.Products.UpdateRange(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}