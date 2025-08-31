using Microsoft.EntityFrameworkCore;

namespace ApiRest_NET9.data;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {
        
    }
}