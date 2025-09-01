using ApiRest_NET9.dtos;
using ApiRest_NET9.entity;

namespace ApiRest_NET9.services;

public class UserService : IUserInterface
{
    public Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<UserModel>> GetUserById(int userId)
    {
        throw new NotImplementedException();
    }
}