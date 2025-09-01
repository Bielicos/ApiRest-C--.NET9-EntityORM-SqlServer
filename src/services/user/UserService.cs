using ApiRest_NET9.data;
using ApiRest_NET9.dtos;
using ApiRest_NET9.models;

namespace ApiRest_NET9.services.user;

public class UserService : IUserInterface
{
    private ApiDbContext _context;

    public UserService(ApiDbContext context)
    {
        this._context = context;
    }
    
    public Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<UserModel>> GetUserById(int userId)
    {
        throw new NotImplementedException();
    }
}