using Bibliotekarz.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Bibliotekarz.Data.Repositories;

public class KeyRepository<T, TKey>(DbContext dbContext, ILogger<IRepository<T>> logger)
    : BaseRepository<T>(dbContext, logger), IKeyRepository<T, TKey>
    where T : BaseEntity<TKey>
    where TKey : struct
{
    private readonly DbContext dbContext = dbContext;

    public async Task<T?> GetById(TKey id)
        => await DbSet.FindAsync(id);

    public async Task<T?> GetById<TProperty>(TKey id, Expression<Func<T, TProperty>> include)
        => await DbSet.Include(include).FirstOrDefaultAsync(x => x.Id.Equals(id));

    public async Task DeleteAsync(TKey id)
    {
        T? entity = await DbSet.FindAsync(id);
        if (entity == null)
            throw new InvalidOperationException($"Entity {typeof(T).Name} with id {id} not found.");

        DbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}