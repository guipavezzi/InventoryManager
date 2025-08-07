using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RefreshTokenController : ControllerBase
{
    private readonly RegisterNewRefreshToken _registerNewRefreshToken;
    public RefreshTokenController(RegisterNewRefreshToken registerNewRefreshToken)
    {
        _registerNewRefreshToken = registerNewRefreshToken;
    }

    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] UserLoginResponse request)
    {
        return Ok(await _registerNewRefreshToken.RegisterNewToken(request));
    }
}