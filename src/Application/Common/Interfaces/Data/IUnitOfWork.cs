namespace imPhotoshop.Application.Common.Interfaces.Data;

public interface IUnitOfWork : IDisposable
{
    Task<int> CommitAsync(CancellationToken cancellationToken);
}