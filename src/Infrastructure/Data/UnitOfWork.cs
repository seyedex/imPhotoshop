using imPhotoshop.Application.Common.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace imPhotoshop.Infrastructure.Data;

internal class UnitOfWork : IUnitOfWork
{
    #region Variables

    private bool _disposed = false;
    private readonly DbFactory _dbFactory;

    #endregion // Variables


    #region Properties

    protected DbContext Context => _dbFactory.DbContext;

    #endregion // Properties


    #region Constructor

    public UnitOfWork(DbFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }

    #endregion // Constructor


    #region Methods

    public void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbFactory.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return this.Context.SaveChangesAsync(cancellationToken);
    }

    #endregion // Methods
}