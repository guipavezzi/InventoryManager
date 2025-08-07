public interface IRefreshTokenRepository
{
    Task<RefreshToken> Add(RefreshToken token);
    Task<RefreshToken> GetToken(string token);
    Task<RefreshToken> Update(RefreshToken token);
}