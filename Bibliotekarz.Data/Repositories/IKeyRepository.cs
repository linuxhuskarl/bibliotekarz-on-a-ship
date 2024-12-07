using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarz.Data.Repositories;

public interface IKeyRepository<T, in TKey> : IRepository<T>
    where T : class
    where TKey : struct
{
    Task<T?> GetById(TKey id);
    Task<T?> GetById<TProperty>(TKey id, Expression<Func<T, TProperty>> include);
    Task DeleteAsync(TKey id);
}

