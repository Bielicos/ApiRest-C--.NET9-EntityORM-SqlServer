 using ApiRest_NET9.controllers.user.dtos;
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

    [HttpGet("getUserById/{userId:int}")]
    public async Task<ActionResult<ResponseModel<UserModel>>> getUserById(int userId)
    {
        var user = await _userInterface.GetUserById(userId);
        return Ok(user);
    }

    [HttpPost("createUser")]
    public async Task<ActionResult<ResponseModel<UserModel>>> createUser(CreateUserDto dto)
    {
        var newUser = await _userInterface.CreateUser(dto);
        return Created($"/api/users/{newUser.Data.UserId}",  newUser);
    }

    [HttpPut("updateUser/{userId:int}")]
    public async Task<ActionResult<ResponseModel<UserModel>>> updateUser(int UserId, UpdateUserDto dto)
    {
        var user = await _userInterface.UpdateUser(UserId, dto);
        return Ok(user);
    }

    [HttpDelete("deleteUser/{userId:int}")]
    public async Task<ActionResult<ResponseModel<String>>> deleteUser(int UserId)
    {
        var user = await _userInterface.DeleteUser(UserId);
        return Ok(user);
    }
}