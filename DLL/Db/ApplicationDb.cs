using DLL.Models;
using Microsoft.EntityFrameworkCore;

namespace DLL.Db;

public sealed class ApplicationDb : DbContext
{
    public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Channel> Channels => Set<Channel>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Inbox> Inboxes => Set<Inbox>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<Operator> Operators => Set<Operator>();
    public DbSet<Team> Teams => Set<Team>();
}