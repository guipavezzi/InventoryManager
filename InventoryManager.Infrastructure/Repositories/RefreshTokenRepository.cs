
public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly ContextDB _context;
    public RefreshTokenRepository(ContextDB context)
    {
        _context = context;
    }
    public async Task<RefreshToken> Add(RefreshToken token)
    {
        await _context.RefreshTokens.AddAsync(token);
        await _context.SaveChangesAsync();
        return token;
    }
}