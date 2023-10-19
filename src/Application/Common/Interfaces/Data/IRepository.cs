using imPhotoshop.Domain.Common;

namespace imPhotoshop.Application.Common.Interfaces.Data;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}