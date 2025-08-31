using ApiRest_NET9.services;

var builder =  WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UserService>();

builder.Services.AddControllers();

var app =  builder.Build(); 

app.MapControllers(); 

app.Run(); 
