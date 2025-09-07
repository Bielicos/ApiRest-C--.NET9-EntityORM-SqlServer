using ApiRest_NET9.data;
using ApiRest_NET9.controllers.user.dtos;
using ApiRest_NET9.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.services.user;

public class UserService : IUserInterface
{
    private readonly ApiDbContext _context;
    private readonly IPasswordHasher<UserModel> _passwordHasher;

    public UserService(ApiDbContext context,  IPasswordHasher<UserModel> passwordHasher)
    {
        this._context = context;
        this._passwordHasher = passwordHasher;
    }

    public async Task<ResponseModel<UserModel>> CreateUser(CreateUserDto dto)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            if (dto == null)
            {
                throw new Exception("Dto is empty :(");
            }
            
            var newUser = new UserModel()
            {
                Name = dto.Name,
                Email = dto.Email,
                Projects = new List<ProjectModel>()
            };
            newUser.HashedPassword = this._passwordHasher.HashPassword(newUser, dto.Password);
            
            _context.Add(newUser);
            await _context.SaveChangesAsync();
            response.Data = newUser;
            response.Status = true;
            response.Message = "User created successfully :)";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }

        return response;
    }
    
    public async Task<ResponseModel<List<UserModel>>> GetAllUsers()
    {
        ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
        try
        {
            var users = await _context.Users.ToListAsync();
            if (users.Count == 0)
            {
                throw new Exception("No users found :(");
            }
            else
            {
                response.Data = users;
                response.Status = true;
                response.Message = "All users were collected :)";
            }
        }
        catch (Exception e)
        {
            response.Status = false;
            response.Message = e.Message;
            response.Data = null;
        }
        return response;
    }

    public async Task<ResponseModel<UserModel>> GetUserById(int UserId)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(userInDatabase => userInDatabase.UserId == UserId);
            if (user == null)
            {
                throw new Exception("User not found :(");
            }
            else
            {
                response.Data = user;
                response.Status = true;
                response.Message = "User was found :)";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }
        return response;
    }

    public async Task<ResponseModel<UserModel>> UpdateUser(int UserID, UpdateUserDto dto)
    {
        ResponseModel<UserModel> response = new ResponseModel<UserModel>();
        try
        {
            var userExists = await _context.Users.FirstOrDefaultAsync(userInDatabase => userInDatabase.UserId == UserID);
            if (dto == null)
            {
                throw new Exception("Dto is empty :(");
            }
            if (userExists == null)
            {
                throw new Exception("User not found :(");
            }
            else
            {
                if (dto.Name != null)
                {
                    userExists.Name = dto.Name;
                }

                if (dto.Email != null)
                {
                    userExists.Email = dto.Email;
                }

                if (dto.Password != null)
                {
                    userExists.HashedPassword = this._passwordHasher.HashPassword(userExists, dto.Password);
                }
                
                _context.Users.Update(userExists);
                await _context.SaveChangesAsync();
                response.Data = await _context.Users.FirstOrDefaultAsync(userInDatabase => userInDatabase.UserId == UserID);
                response.Message = "User was updated successfully :)";
                response.Status = true;
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }
        return response;
    }

    public async Task<ResponseModel<String>> DeleteUser(int UserId)
    {
        ResponseModel<String> response = new ResponseModel<String>();
        try
        {
            var userExists = await _context.Users.FirstOrDefaultAsync(userInDatabase => userInDatabase.UserId == UserId);
            if (userExists == null)
            {
                throw new Exception("User not found :(");
            }
            else
            {
                _context.Remove(userExists);
                await _context.SaveChangesAsync();
                response.Data = $"UserID : {UserId}";
                response.Message = "User deleted successfully :)";
                response.Status = true;
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
            response.Status = false;
            response.Data = null;
        }
        return response;
    }
}