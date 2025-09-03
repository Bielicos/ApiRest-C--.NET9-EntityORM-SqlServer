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
        if (dto == null)
            return BadRequest("Request body is null.");

        var result = await _userInterface.CreateUser(dto);

        if (result == null)
            return StatusCode(500, "Internal error: service returned null.");

        // se o serviço indicou erro ou não retornou Data, devolva 400 (ou 500 conforme sua política)
        if (!result.Status || result.Data == null)
        {
            // se quiser diferenciar: return BadRequest(result) ou return StatusCode(500, result);
            return BadRequest(result);
        }

        // retorna 201 apontando para o GET que busca por id
        return CreatedAtAction(nameof(getUserById), new { userId = result.Data.UserId }, result);
    }

    [HttpPut("updateUser/{userId:int}")]
    public async Task<ActionResult<ResponseModel<UserModel>>> updateUser(int UserId, UpdateUserDto dto)
    {
        var user = await _userInterface.UpdateUser(UserId, dto);
        return Ok(user);
    }

    [HttpDelete("deleteUserById/{userId:int}")]
    public async Task<ActionResult<ResponseModel<String>>> deleteUserById(int UserId)
    {
        var user = await _userInterface.DeleteUser(UserId);
        return Ok(user);
    }
}