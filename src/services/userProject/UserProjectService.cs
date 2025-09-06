using ApiRest_NET9.models;

namespace ApiRest_NET9.services.userProject;

public class UserProjectService : IUserProjectInterface
{
    public async Task<ResponseModel<List<ProjectModel>>> GetAllProjectsFromUser(int UserId)
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

    public async Task<ResponseModel<List<UserModel>>> GetAllUsersFromProject(int ProjectId)
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

    public async Task<ResponseModel<string>> associateUserToProject(int ProjectId, int UserId)
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

    public async Task<ResponseModel<string>> DeleteUserFromProject(int ProjectId, int UserId)
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