using ApiRest_NET9.controllers.user.dtos;
using ApiRest_NET9.models;

namespace ApiRest_NET9.services.user;

public interface IUserInterface
{
    Task<ResponseModel<List<UserModel>>> GetAllUsers();
    Task<ResponseModel<UserModel>> GetUserById(int UserId);
    Task<ResponseModel<UserModel>> CreateUser(CreateUserDto dto);
    Task<ResponseModel<UserModel>> UpdateUser(int UserID, UpdateUserDto dto);
    Task<ResponseModel<bool>> DeleteUser(int UserId);
}