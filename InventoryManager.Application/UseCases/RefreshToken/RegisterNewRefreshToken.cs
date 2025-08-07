public class RegisterNewRefreshToken
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtService _jwtService;
    public RegisterNewRefreshToken(IRefreshTokenRepository refreshTokenRepository, JwtService jwtService)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _jwtService = jwtService;
    }

    public async Task<UserLoginResponse> RegisterNewToken(UserLoginResponse request)
    {
        var refreshToken = await _refreshTokenRepository.GetToken(request.RefreshToken);

        if (refreshToken == null || refreshToken.IsRevoked)
            throw new UnauthorizedException("Token Inválido ou Expirado");

        if (refreshToken.Expires < DateTime.UtcNow)
        {
            refreshToken.IsRevoked = true;
            await _refreshTokenRepository.Update(refreshToken);
            throw new UnauthorizedException("Token Expirado");
        }

        var token = _jwtService.GenerateToken(refreshToken.UserId);

        return new UserLoginResponse
        {
            Token = token,
            RefreshToken = refreshToken.Token
        };
    }
}