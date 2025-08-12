
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

    public async Task<IList<Store>> GetStoresByIdUser(Guid userId)
    {
        return await _context.UserStores
                    .Where(us => us.UserId == userId)
                    .Include(us => us.Store)
                    .Select(us => us.Store)
                    .ToListAsync();
    }

    public async Task<bool> StoreExist(string CNPJ)
    {
        return await _context.Stores.AnyAsync(x => x.Cnpj.Equals(CNPJ));
    }

    public async Task<bool> StoreExist(Guid id)
    {
        return await _context.Stores.AnyAsync(x => x.Id == id);
    }
}