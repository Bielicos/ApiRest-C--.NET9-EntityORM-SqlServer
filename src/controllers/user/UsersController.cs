 using ApiRest_NET9.services.user;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_NET9.controllers.user;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private UserService userService;
    public UsersController(UserService userService)
    {
        this.userService = userService;
    }

    // [HttpPost]
    // public ActionResult createNewUser([FromBody] UserDto userDto)
    // {
    //     int userId = userService.createNewUser(userDto);
    // }
}