 using ApiRest_NET9.controllers.user.dtos;
 using ApiRest_NET9.models;
 using ApiRest_NET9.services.user;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_NET9.controllers.user;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserInterface _userInterface;
    public UsersController(IUserInterface userInterface)
    {
        this._userInterface = userInterface;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<List<UserModel>>>> getAllUsers()
    {
        var users = await _userInterface.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("/{userId:int}")]
    public async Task<ActionResult<ResponseModel<UserModel>>> getUserById(int userId)
    {
        var user = await _userInterface.GetUserById(userId);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseModel<UserModel>>> createUser(CreateUserDto dto)
    {
        var result = await _userInterface.CreateUser(dto);
        return CreatedAtAction(nameof(getUserById), new { userId = result.Data.UserId }, result);
    }

    [HttpPut("/{userId:int}")]
    public async Task<ActionResult<ResponseModel<UserModel>>> updateUser(int UserId, UpdateUserDto dto)
    {
        var user = await _userInterface.UpdateUser(UserId, dto);
        return Ok(user);
    }

    [HttpDelete("/{userId:int}")]
    public async Task<ActionResult<ResponseModel<String>>> deleteUserById(int UserId)
    {
        var user = await _userInterface.DeleteUser(UserId);
        return Ok(user);
    }
}