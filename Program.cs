using ApiRest_NET9.data;
using ApiRest_NET9.services.project;
using ApiRest_NET9.services.user;
using Microsoft.EntityFrameworkCore;

var builder =  WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IProjectInterface,  ProjectService>();

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
