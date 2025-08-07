using Microsoft.AspNetCore.Mvc;

public class LoginUser
{
    private readonly IUserRepository _userRepository;
    private readonly JwtService _jwtService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    public LoginUser(IUserRepository userRepository, JwtService jwtService, IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _refreshTokenRepository = refreshTokenRepository;
    }
    public async Task<UserLoginResponse> Execute(RequestUserLogin request)
    {
        var passwordCryptography = new PasswordHasher();
        var user = await _userRepository.GetUser(request.Email);

        if (user is null || !passwordCryptography.Verify(request.Password, user.Password, user.Salt))
            throw new UnauthorizedException("Credenciais Incorretas");

        var token = _jwtService.GenerateToken(user.Id);

        var refreshTokenValue = GenerateRefreshToken();

        RefreshToken refreshToken = new RefreshToken
        {
            Token = refreshTokenValue,
            Expires = DateTime.UtcNow.AddDays(7),
            CreatedAt = DateTime.UtcNow,
            UserId = user.Id,
            IsRevoked = false
        };

        await _refreshTokenRepository.Add(refreshToken);

        return new UserLoginResponse
        {
            Token = token,
            RefreshToken = refreshToken.Token
        };
    }

     private string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        return Convert.ToBase64String(randomBytes);
    }
}