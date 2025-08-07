
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

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

    public async Task<RefreshToken> GetToken(string token)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task<RefreshToken> Update(RefreshToken token)
    {
        _context.RefreshTokens.Update(token);
        await _context.SaveChangesAsync();
        return token;
    }
}