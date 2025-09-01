using ApiRest_NET9.entity;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.data;

public class ApiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }
    
    // Criação das tabelas
    public DbSet<UserModel> users { get; set; }
    public DbSet<BookModel> books { get; set; }
    public DbSet<AuthorModel> authors { get; set; }
}