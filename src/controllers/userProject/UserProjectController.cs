using ApiRest_NET9.models;
using ApiRest_NET9.services.userProject;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_NET9.controllers.userProject;

[ApiController]
public class UserProjectController : ControllerBase
{
    IUserProjectInterface _userProjectInterface;

    public UserProjectController(IUserProjectInterface userProjectInterface)
    {
        _userProjectInterface = userProjectInterface;
    }


    [HttpGet("projects/{ProjectId:int}/users")] 
    public async Task<ActionResult<ResponseModel<List<UserModel>>>> getAllUsersFromProject([FromRoute] int ProjectId) 
    {
        var response = await _userProjectInterface.GetAllUsersFromProject(ProjectId);
        return Ok(response);
    }

    [HttpGet("users/{UserId:int}/projects")]
    public async Task<ActionResult<ResponseModel<List<ProjectModel>>>> getAllProjectsFromUser([FromRoute] int UserId)
    {
        var response = await _userProjectInterface.GetAllProjectsFromUser(UserId);
        return Ok(response);
    }

    [HttpPut("projects/{ProjectId:int}/users/{UserId:int}")]
    public async Task<ActionResult<ResponseModel<String>>> associateUserToProject([FromRoute] int ProjectId, [FromRoute] int UserId)
    {
        var response = await _userProjectInterface.AssociateUserToProject(ProjectId, UserId);
        return Ok(response);
    }

    [HttpDelete("projects/{ProjectId:int}/users/{UserId:int}")]
    public async Task<ActionResult<ResponseModel<String>>> disassociateUserFromProject([FromRoute] int ProjectId, [FromRoute] int UserId)
    {
        var response = await _userProjectInterface.DisassociateUserFromProject(ProjectId, UserId);
        return Ok(response);
    }
}