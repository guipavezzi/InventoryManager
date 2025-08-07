using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StoresController : ControllerBase
{
    private readonly RegisterStore _registerStore;
    public StoresController(RegisterStore registerStore)
    {
        _registerStore = registerStore;
    }

    [HttpPost]
    [Route("register")]
    [Authorize]
    [ProducesResponseType(typeof(StoreRegisterResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register(RequestRegisterStore request)
    {
        return Created(string.Empty, await _registerStore.Execute(request));
    }
}