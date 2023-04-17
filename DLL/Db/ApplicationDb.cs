using DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Db;

public sealed class ApplicationDb : DbContext
{
    public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Message> Messages => Set<Message>();
}