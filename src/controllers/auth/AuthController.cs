using ApiRest_NET9.controllers.auth.dtos;
using ApiRest_NET9.models;
using ApiRest_NET9.services.auth;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_NET9.controllers.auth;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private IAuthInterface _authInterface;

    public AuthController(IAuthInterface authInterface)
    {
        _authInterface = authInterface;
    }
    [HttpPost("login")]
    public async Task<ActionResult<ResponseModel<String>>> login(LoginDto dto)
    {
        var response = await _authInterface.Login(dto);
        return Ok(response);
    }
}