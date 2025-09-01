using ApiRest_NET9.models;

namespace ApiRest_NET9.services.user;

public interface IUserInterface
{
    Task<ResponseModel<List<UserModel>>> GetAllUsers();
    Task<ResponseModel<UserModel>> GetUserById(int userId);
}