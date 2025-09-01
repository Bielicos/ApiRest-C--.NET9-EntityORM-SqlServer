using ApiRest_NET9.data;
using ApiRest_NET9.dtos;
using ApiRest_NET9.models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.services.user;

public class UserService : IUserInterface
{
    private readonly ApiDbContext _context;

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
    
    public async Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
        try
        {
            var users = await _context.users.ToListAsync();
            if (users.Count == 0)
            {
                throw new Exception("No users found :(");
            }
            else
            {
                response.Data = users;
                response.Message = "All users were collected :)";
            }
        }
        catch (Exception e)
        {
            response.Status = false;
            response.Message = e.Message;
        }
        return response;
    }

    public async Task<ResponseModel<UserModel>> GetUserById(int userId)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            var user = await _context.users.FirstOrDefaultAsync();
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
        }
        return response;
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