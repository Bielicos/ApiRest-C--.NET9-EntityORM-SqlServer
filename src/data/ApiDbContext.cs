using ApiRest_NET9.models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.data;

public class ApiDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<ProjectModel> Projects { get; set; }
}