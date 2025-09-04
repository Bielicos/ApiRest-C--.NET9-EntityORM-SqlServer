using ApiRest_NET9.controllers.project.dtos;
using ApiRest_NET9.data;
using ApiRest_NET9.models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.services.project;

public class ProjectService : IProjectInterface
{
    private readonly ApiDbContext _dbContext;
    public ProjectService(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ResponseModel<ProjectModel>> getProjectById(int ProjectId)
    {
        ResponseModel<ProjectModel> response = new ResponseModel<ProjectModel>();
        try
        {
           var projectExists = await _dbContext.Projects.FirstOrDefaultAsync(projectInDatabase => projectInDatabase.ProjectId == ProjectId);

           if (projectExists == null)
           {
               throw new Exception("Project not found");
           }
           else
           {
               response.Data = projectExists;
               response.Status = true;
               response.Message = "Project found :)";
           }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }
        return response;
    }

    public async Task<ResponseModel<List<ProjectModel>>> getAllProjects()
    {
        ResponseModel<List<ProjectModel>> response = new ResponseModel<List<ProjectModel>>();
        try
        {
            var AllProjects = await _dbContext.Projects.ToListAsync();
            if (AllProjects.Count == 0)
            {
                throw new Exception("No projects found");
            }
            else
            {
                response.Data = AllProjects;
                response.Message = "All projects found";
                response.Status = true;
            }
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
            var newProject = new ProjectModel()
            {
                Title = dto.Title,
                Description = dto.Description,
            };
            
            _dbContext.Projects.Add(newProject);
            await _dbContext.SaveChangesAsync();
            
            response.Data = newProject;
            response.Status = true;
            response.Message = "Project created successfully.";
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
           var projectExists = await  _dbContext.Projects.FirstOrDefaultAsync(projectInDatabase => projectInDatabase.ProjectId == ProjectId);

           if (projectExists == null)
           {
               throw new Exception("Project not found");
           }
           else
           {
               if (dto.Title != null)
               {
                   projectExists.Title = dto.Title;
               }

               if (dto.Description != null)
               {
                   projectExists.Description = dto.Description;
               }
               
               _dbContext.Projects.Update(projectExists);
               await _dbContext.SaveChangesAsync();
               response.Data = projectExists;
               response.Status = true;
               response.Message = "Project updated successfully.";
           }
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
           var projectExists = await  _dbContext.Projects.FirstOrDefaultAsync(projectInDatabase => projectInDatabase.ProjectId == ProjectId);
           if (projectExists == null)
           {
               throw new Exception("Project not found");
           }
           else
           {
               _dbContext.Projects.Remove(projectExists);
               await _dbContext.SaveChangesAsync();
               response.Data = $"ProjectId : {ProjectId}}";
               response.Status = true;
               response.Message = "Project deleted successfully.";
           }
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