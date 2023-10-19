using imPhotoshop.Domain.Common;
using Microsoft.EntityFrameworkCore;
using imPhotoshop.Application.Common.Interfaces.Data;

namespace imPhotoshop.Infrastructure.Data;

internal class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    #region Properties

    public DbSet<TEntity> Entities { get; set; } 

    #endregion // Properties


    #region Methods

    public void Add(TEntity entity)
    {
        Entities.Add(entity);
    }

    public void Remove(TEntity entity)
    {
        Entities.Remove(entity);
    }

    public Task<TEntity?> GetById(int id)
    {
        return Task.FromResult(Entities.FirstOrDefault(e => e.Id == id));
    }

    public void Update(TEntity entity)
    {
        Entities.Update(entity);
    }

    #endregion // Methods
}