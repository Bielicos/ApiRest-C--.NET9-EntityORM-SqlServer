using ApiRest_NET9.controllers.project.dtos;
using ApiRest_NET9.models;

namespace ApiRest_NET9.services.project;

public interface IProjectInterface
{
    Task<ResponseModel<ProjectModel>> getProjectById(int ProjectId);
    
    Task<ResponseModel<ProjectModel>> getAllProjects();
    
    Task<ResponseModel<ProjectModel>> createNewProject(CreateProjectDto dto);
    
    Task<ResponseModel<ProjectModel>> updateProject(int ProjectId, UpdateProjectDto dto);
    
    Task<ResponseModel<String>> deleteProject(int ProjectId);
}