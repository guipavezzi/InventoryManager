using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly RegisterSale _registerSale;
    public SalesController(RegisterSale registerSale)
    {
        _registerSale = registerSale;
    }

    [HttpPost]
    [Route("register/{storeId}")]
    [Authorize]
    public async Task<IActionResult> Register([FromBody] IList<RequestProductsSale> products, [FromRoute] Guid storeId)
    {
        return Created(string.Empty, await _registerSale.Execute(products, storeId));
    }
}