using ApiRest_NET9.data;
using ApiRest_NET9.models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.services.userProject;

public class UserProjectService : IUserProjectInterface
{
    private readonly ApiDbContext _context;

    public UserProjectService(ApiDbContext context)
    {
        this._context = context;
    }
    public async Task<ResponseModel<List<ProjectModel>>> GetAllProjectsFromUser(int UserId)
    {
        ResponseModel<List<ProjectModel>> response = new ResponseModel<List<ProjectModel>>();
        try
        {
            var userExists = await _context.Users
                .Include(u => u.Projects)
                .FirstOrDefaultAsync(userInDatabase  => userInDatabase.UserId == UserId);
            if (userExists == null)
            {
                throw new Exception("User not found");
            } else if (userExists.Projects.Count == 0)
            {
                throw new Exception("No projects found");
            }
            else
            {
                response.Data = userExists.Projects.ToList();
                response.Message = "Success! These are all projects from that user!";
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

    public async Task<ResponseModel<List<UserModel>>> GetAllUsersFromProject(int ProjectId)
    {
        ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
        try
        {
            var projectExists = await _context.Projects
                .Include(p => p.Users)
                .FirstOrDefaultAsync(projectFromDatabase => projectFromDatabase.ProjectId == ProjectId);
            if (projectExists == null)
            {
                throw new Exception("Project not found in database");
            } else if (projectExists.Users.Count == 0)
            {
                throw new Exception("No users found in project");
            }
            else
            {
                response.Data = projectExists.Users.ToList();
                response.Message = "Success! These are all users from that project!";
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

    public async Task<ResponseModel<string>> associateUserToProject(int ProjectId, int UserId)
    {
        ResponseModel<String> response = new ResponseModel<String>();
        try
        {
            var userExists = await _context.Users
                .Include(u => u.Projects)
                .FirstOrDefaultAsync(userInDatabase => userInDatabase.UserId == UserId);
            
            if (userExists == null)
            {
                throw new Exception("User not found in database");
            }
            
            var projectExists = await _context.Projects
                .FirstOrDefaultAsync(projectFromDatabase => projectFromDatabase.ProjectId == ProjectId);

            if (projectExists == null)
            {
                throw new Exception("Project not found in database");
            }
            
            var userAlreadyIsAssociatedToProject = userExists
                .Projects.Any(u => u.ProjectId == ProjectId);
            
            if (userAlreadyIsAssociatedToProject)
            {
                throw new Exception("User already is associated to project");
            }
            
            userExists.Projects.Add(projectExists);
            await _context.SaveChangesAsync();
            
            response.Message = "Success! User associated to project!";
            response.Status = true;
            response.Data = $"UserID : {UserId} | ProjectID : {ProjectId}";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }
        return response;
    }

    public async Task<ResponseModel<string>> DisassociateUserFromProject(int ProjectId, int UserId)
    {
        ResponseModel<String> response = new ResponseModel<String>();
        try
        {
            var userExists = await _context.Users
                .Include(u => u.Projects)
                .FirstOrDefaultAsync(userInDatabase => userInDatabase.UserId == UserId);
            
            if (userExists == null)
            {
                throw new Exception("User not found in database");
            }
            
            var projectExists = await _context.Projects
                .FirstOrDefaultAsync(projectFromDatabase => projectFromDatabase.ProjectId == ProjectId);

            if (projectExists == null)
            {
                throw new Exception("Project not found in database");
            }
            
            var userAlreadyIsAssociatedToProject = userExists
                .Projects.Any(u => u.ProjectId == ProjectId);
            
            if (!userAlreadyIsAssociatedToProject)
            {
                throw new Exception("User isn't associated to project");
            }
            
            userExists.Projects.Remove(projectExists);
            await _context.SaveChangesAsync();
            response.Message = "Success! User associated to project!";
            response.Status = true;
            response.Data = $"UserID : {UserId} | ProjectID : {ProjectId}";
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