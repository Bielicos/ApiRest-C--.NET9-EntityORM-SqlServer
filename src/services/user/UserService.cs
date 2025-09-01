using ApiRest_NET9.data;
using ApiRest_NET9.controllers.user.dtos;
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

    public async Task<ResponseModel<UserModel>> CreateUser(CreateUserDto dto)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            var newUser = new UserModel()
            {
                name = dto.name,
                email = dto.email,
                password = dto.password
            };
            _context.Add(newUser);
            await _context.SaveChangesAsync();
            response.Data = await _context.users.FirstOrDefaultAsync(newUserInsideDatabase => newUserInsideDatabase.UserId == newUser.UserId);
            response.Message = "User created successfully :)";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
        }

        return response;
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

    public async Task<ResponseModel<UserModel>> GetUserById(int UserId)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            var user = await _context.users.FirstOrDefaultAsync(userInDatabase => userInDatabase.userId == UserId);
            if (user == null)
            {
                throw new Exception("User not found :(");
            }
            else
            {
                response.Data = user;
                response.Message = "User was found :)";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
        }
        return response;
    }

    public async Task<ResponseModel<UserModel>> UpdateUser(int UserID, UpdateUserDto dto)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            var userExists = _context.users.FirstOrDefaultAsync(userInDatabase => userInDatabase.UserId == UserID);
            if (userExists == null)
            {
                throw new Exception("User not found :(");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e);
            throw;
        }
        return response;
    }

    public Task<ResponseModel<bool>> DeleteUser(int UserId)
    {
        try
        {
            var userExists = _context.users.FirstOrDefaultAsync(userInDatabase => userInDatabase.userId == UserId);
            if (userExists == null)
            {
                throw new Exception("User not found :(");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e);
            throw;
        }
    }
}