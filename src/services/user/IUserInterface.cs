using ApiRest_NET9.entity;

namespace ApiRest_NET9.services;

public interface IUserInterface
{
    Task<ResponseModel<List<UserModel>>> GetAllUsers();
    Task<ResponseModel<UserModel>> GetUserById(int userId);
}