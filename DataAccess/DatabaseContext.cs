using Application.Abstractions.DataAccess;
using Domain.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        // TODO connection
        Database.EnsureCreated();
    }

    public DbSet<Board>? Boards { get; private init; }
    public DbSet<ToDoTask>? Tasks { get; private init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }
}