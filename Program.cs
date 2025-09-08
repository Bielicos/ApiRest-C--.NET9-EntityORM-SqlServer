using ApiRest_NET9.data;
using ApiRest_NET9.models;
using ApiRest_NET9.services.auth;
using ApiRest_NET9.services.project;
using ApiRest_NET9.services.user;
using ApiRest_NET9.services.userProject;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();

var builder =  WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IProjectInterface, ProjectService>();
builder.Services.AddScoped<IUserProjectInterface,  UserProjectService>();
builder.Services.AddScoped<IAuthInterface, AuthService>();

builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();

var app =  builder.Build();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    db.Database.Migrate();
}

app.Run(); 
