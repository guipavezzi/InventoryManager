using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    public ProductsController()
    {

    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }

}