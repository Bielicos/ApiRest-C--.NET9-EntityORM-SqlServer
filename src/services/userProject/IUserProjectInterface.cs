using ApiRest_NET9.models;

namespace ApiRest_NET9.services.userProject;

public interface IUserProjectInterface
{
    Task<ResponseModel<List<ProjectModel>>> GetAllProjectsFromUser(int UserId);
    
    Task<ResponseModel<List<UserModel>>> GetAllUsersFromProject(int ProjectId);
    
    Task<ResponseModel<String>> associateUserToProject(int ProjectId, int UserId);
    
    Task<ResponseModel<String>> DeleteUserFromProject(int  ProjectId, int UserId);
}