using Microsoft.EntityFrameworkCore;
using RfidAccessControl.Api.Models;

namespace RfidAccessControl.Api;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<AccessLog> AccessLogs => Set<AccessLog>();
}