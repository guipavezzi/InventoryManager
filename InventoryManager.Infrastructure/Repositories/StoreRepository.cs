
using Microsoft.EntityFrameworkCore;

public class StoreRepository : IStoreRepository
{
    private readonly ContextDB _context;
    public StoreRepository(ContextDB context)
    {
        _context = context;
    }
    public async Task<Store> Add(Store entity)
    {
        await _context.Stores.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public Task<bool> StoreExist(string CNPJ)
    {
        return _context.Stores.AnyAsync(x => x.Cnpj.Equals(CNPJ));
    }
}