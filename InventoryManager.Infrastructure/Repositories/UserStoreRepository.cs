
public class UserStoreRepository : IUserStoreRepository
{
    private readonly ContextDB _context;

    public UserStoreRepository(ContextDB context)
    {
        _context = context;
    }

    public async Task<UserStore> Add(UserStore entity)
    {
        await _context.UserStores.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}