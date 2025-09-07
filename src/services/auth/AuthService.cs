using ApiRest_NET9.controllers.auth.dtos;
using ApiRest_NET9.data;
using ApiRest_NET9.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.services.auth;

public class AuthService : IAuthInterface
{
    private readonly ApiDbContext _context;
    private readonly IPasswordHasher<UserModel> _passwordHasher;

    public AuthService(ApiDbContext context,  IPasswordHasher<UserModel> passwordHasher)
    {
        this._context = context;
        this._passwordHasher = passwordHasher;
    }
    
    public async Task<ResponseModel<String>> Login(LoginDto dto)
    {
        ResponseModel<String> response = new ResponseModel<String>();
        try
        {
           var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
           if (userExists == null)
           {
               throw new Exception("Wrong credentials when trying to login"); 
           }
           
           var passwordIsCorrect =  _passwordHasher.VerifyHashedPassword(userExists, userExists.HashedPassword, dto.Password);
           if (passwordIsCorrect == PasswordVerificationResult.Failed)
           {
               throw new Exception("Wrong credentials when trying to login");
           }

           String token = "Mocking the jwt token hahahah!";

           response.Message = "Login was successful!";
           response.Data = token;
           response.Status = true;
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