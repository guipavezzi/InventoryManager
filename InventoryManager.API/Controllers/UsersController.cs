using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly RegisterUser _registerUser;
    private readonly LoginUser _loginUser;

    public UsersController(RegisterUser registerUser, LoginUser loginUser)
    {
        _registerUser = registerUser;
        _loginUser = loginUser;
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(typeof(FluentValidationException), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserRegisterResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register(RequestUserRegister request)
    {
        return Created(string.Empty, await _registerUser.Execute(request));
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(RequestUserLogin request)
    {
        return Ok(await _loginUser.Execute(request));
    }
}