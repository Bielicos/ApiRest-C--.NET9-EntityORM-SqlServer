using ApiRest_NET9.dtos;
using ApiRest_NET9.models;

namespace ApiRest_NET9.services.user;

public interface IUserInterface
{
    Task<ResponseModel<List<UserModel>>> GetAllUsers();
    Task<ResponseModel<UserModel>> GetUserById(int userId);
    Task<ResponseModel<UserModel>> CreateUser(CreateUserDto dto);
    Task<ResponseModel<UserModel>> UpdateUser(int userId, updateUserDto dto);
    Task<ResponseModel<bool>> DeleteUser(int userId);
}