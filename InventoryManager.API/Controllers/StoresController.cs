using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StoresController : ControllerBase
{
    private readonly RegisterStore _registerStore;
    private readonly GetStores _getStores;
    public StoresController(RegisterStore registerStore,
                            GetStores getStores)
    {
        _registerStore = registerStore;
        _getStores = getStores;
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

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetStores()
    {
        return Ok(await _getStores.Execute());
    }
}