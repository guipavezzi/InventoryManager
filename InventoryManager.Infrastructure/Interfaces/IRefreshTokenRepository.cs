public interface IRefreshTokenRepository
{
    Task<RefreshToken> Add(RefreshToken token);
}