using Domain.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IDatabaseContext
{
    DbSet<Board> Boards { get; }
    DbSet<ToDoTask> Tasks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}