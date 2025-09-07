using ApiRest_NET9.models;

namespace ApiRest_NET9.services.userProject;

public interface IUserProjectInterface
{
    Task<ResponseModel<List<ProjectModel>>> GetAllProjectsFromUser(int UserId);
    
    Task<ResponseModel<List<UserModel>>> GetAllUsersFromProject(int ProjectId);
    
    Task<ResponseModel<String>> AssociateUserToProject(int ProjectId, int UserId);
    
    Task<ResponseModel<String>> DisassociateUserFromProject(int  ProjectId, int UserId);
}