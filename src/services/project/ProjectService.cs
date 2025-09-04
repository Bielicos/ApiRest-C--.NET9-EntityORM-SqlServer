using ApiRest_NET9.controllers.project.dtos;
using ApiRest_NET9.models;

namespace ApiRest_NET9.services.project;

public class ProjectService : IProjectInterface
{
    public async Task<ResponseModel<ProjectModel>> getProjectById(int ProjectId)
    {
        ResponseModel<ProjectModel> response = new ResponseModel<ProjectModel>();
        try
        {
           
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }

        return response;
    }

    public async Task<ResponseModel<ProjectModel>> getAllProjects()
    {
        ResponseModel<ProjectModel> response = new ResponseModel<ProjectModel>();
        try
        {
           
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }

        return response;    
    }

    public async Task<ResponseModel<ProjectModel>> createNewProject(CreateProjectDto dto)
    {
        ResponseModel<ProjectModel> response = new ResponseModel<ProjectModel>();
        try
        {
           
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }

        return response;
    }

    public async Task<ResponseModel<ProjectModel>> updateProject(int ProjectId, UpdateProjectDto dto)
    {
        ResponseModel<ProjectModel> response = new ResponseModel<ProjectModel>();
        try
        {
           
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }

        return response;
    }

    public async Task<ResponseModel<string>> deleteProject(int ProjectId)
    {
        ResponseModel<String> response = new ResponseModel<String>();
        try
        {
           
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }

        return response;
    }
}