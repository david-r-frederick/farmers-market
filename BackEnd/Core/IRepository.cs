﻿namespace Core;

using Core.DataModel.Entities;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(int id);

    Task AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(int id);
}
