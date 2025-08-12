using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly RegisterProduct _registerProduct;
    public ProductsController(RegisterProduct registerProduct)
    {
        _registerProduct = registerProduct;
    }

    [Authorize]
    [HttpPost]
    [Route("register/{storeId}")]
    public async Task<IActionResult> Register([FromBody]RequestProductRegister request, [FromRoute] Guid storeId)
    {
        return Created(string.Empty, await _registerProduct.Execute(request, storeId));
    }
}