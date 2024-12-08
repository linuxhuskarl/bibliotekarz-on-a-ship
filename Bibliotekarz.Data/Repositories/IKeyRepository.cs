﻿using System.Linq.Expressions;

namespace Bibliotekarz.Data.Repositories;

public interface IKeyRepository<T, in TKey> : IRepository<T>
    where T : class
    where TKey : struct
{
    Task<T?> GetById(TKey id);
    Task<T?> GetById<TProperty>(TKey id, Expression<Func<T, TProperty>> include);
    Task DeleteAsync(TKey id);
}

