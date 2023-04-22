using Application.Abstractions.DataAccess;
using DataAccess.ValueConverters;
using Domain.Common.ValueObjects;
using Domain.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

internal class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Board> Boards { get; private init; } = null!;
    public DbSet<ToDoTask> Tasks { get; private init; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<NonEmptyString>().HaveConversion<NonEmptyStringConverter>();
    }
}