using ApiRest_NET9.models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.data;

public class ApiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }
    
    // Criação das tabelas
    public DbSet<UserModel> users { get; set; }
    public DbSet<ProjectModel> books { get; set; }
}