 using ApiRest_NET9.models;
 using ApiRest_NET9.services.user;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_NET9.controllers.user;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserInterface _userInterface;
    public UsersController(IUserInterface userInterface)
    {
        this._userInterface = userInterface;
    }

    [HttpGet("getAllUsers")]
    public async Task<ActionResult<ResponseModel<List<UserModel>>>> getAllUsers()
    {
        var users = await _userInterface.GetAllUsers();
        return Ok(users);
    }
    
}