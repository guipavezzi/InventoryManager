using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly RegisterUser _registerUser;

    public UsersController(RegisterUser registerUser)
    {
        _registerUser = registerUser;
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(typeof(FluentValidationException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserRegisterResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(RequestUserRegister request)
    {
        return Created(string.Empty, await _registerUser.Execute(request));
    }
}