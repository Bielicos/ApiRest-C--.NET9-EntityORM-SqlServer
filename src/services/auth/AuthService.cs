using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiRest_NET9.controllers.auth.dtos;
using ApiRest_NET9.data;
using ApiRest_NET9.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ApiRest_NET9.services.auth;

public class AuthService : IAuthInterface
{
    private readonly ApiDbContext _context;
    private readonly IPasswordHasher<UserModel> _passwordHasher;
    private readonly IConfiguration _configuration;

    public AuthService(ApiDbContext context,  IPasswordHasher<UserModel> passwordHasher,  IConfiguration configuration)
    {
        this._context = context;
        this._passwordHasher = passwordHasher;
        this._configuration = configuration;
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

           var claims = new List<Claim>
           {
               new Claim(JwtRegisteredClaimNames.Sub, userExists.UserId.ToString()),
               new Claim(JwtRegisteredClaimNames.Email, userExists.Email)
           };
           
           var key = new SymmetricSecurityKey(
               Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
           
           var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

           var tokenDescriptor = new JwtSecurityToken(
               issuer: _configuration.GetValue<String>("AppSettings:Issuer"),
               audience: _configuration.GetValue<String>("AppSettings:Audience"),
               claims: claims,
               expires: DateTime.Now.AddHours(1),
               signingCredentials: creds
               );
           
           var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
           response.Data = token;
           response.Message = "Successfuly logged in! Here is your JWT Token!";
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