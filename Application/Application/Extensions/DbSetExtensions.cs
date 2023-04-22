using Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Extensions;

public static class DbSetExtensions
{
    public static async Task<T?> FindEntityByIdAsync<T>(this DbSet<T> set, Guid id, CancellationToken cancellationToken)
        where T : class
    {
        return await set.FindAsync(new object[] { id }, cancellationToken);
    }

    public static async Task<T> GetEntityByIdAsync<T>(this DbSet<T> set, Guid id, CancellationToken cancellationToken)
        where T : class
    {
        var entity = await set.FindEntityByIdAsync(id, cancellationToken);

        if (entity is null)
        {
            throw NotFoundException.EntityById(id);
        }

        return entity;
    }
}