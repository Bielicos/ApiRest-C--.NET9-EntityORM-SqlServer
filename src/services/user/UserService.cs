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

    public Task<ResponseModel<UserModel>> CreateUser(CreateUserDto dto)
    {
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e);
            throw;
        }
    }
    
    public Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e);
            throw;
        }
    }

    public Task<ResponseModel<UserModel>> GetUserById(int userId)
    {
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e);
            throw;
        }
    }

    public Task<ResponseModel<UserModel>> UpdateUser(int userId, updateUserDto dto)
    {
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e);
            throw;
        }
    }

    public Task<ResponseModel<bool>> DeleteUser(int userId)
    {
        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e);
            throw;
        }
    }
}