using ApiRest_NET9.controllers.project.dtos;
using ApiRest_NET9.models;
using ApiRest_NET9.services.project;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_NET9.controllers.project;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private IProjectInterface _projectInterface;

    public ProjectsController(IProjectInterface projectInterface)
    {
        this._projectInterface = projectInterface;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseModel<List<ProjectModel>>>> getAllProjects()
    {
        var response = await _projectInterface.getAllProjects();
        return Ok(response);
    }

    [HttpGet("{ProjectId:int}")]
    public async Task<ActionResult<ResponseModel<ProjectModel>>> getProjectById(int ProjectId)
    {
        var response = await _projectInterface.getProjectById(ProjectId);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseModel<ProjectModel>>> createNewProject(CreateProjectDto dto)
    {
        var response = await _projectInterface.createNewProject(dto);
        return Ok(response);
    }

    [HttpPut("{ProjectId:int}")]
    public async Task<ActionResult<ResponseModel<ProjectModel>>> updateProject(int ProjectId, UpdateProjectDto dto)
    {
        var response = await  _projectInterface.updateProject(ProjectId, dto);
        return Ok(response);
    }

    [HttpDelete("{ProjectId:int}")]
    public async Task<ActionResult<ResponseModel<String>>> deleteProject(int ProjectId)
    {
        var response = await _projectInterface.deleteProject(ProjectId);
        return Ok(response);
    }
}