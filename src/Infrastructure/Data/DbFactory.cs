using Microsoft.EntityFrameworkCore;

namespace imPhotoshop.Infrastructure.Data;

internal class DbFactory : IDisposable
{
    #region Variables

    private bool _disposed;
    private DbContext _dbContext;
    private Func<ApplicationDbContext> _dbContextFactory;

    #endregion // Variables


    #region Properties

    public DbContext DbContext
    {
        get
        {
            if (_dbContext == null)
            {
                _dbContext = _dbContextFactory.Invoke();
            }
            return _dbContext;
        }
    }

    #endregion // Properties


    #region Constructor

    public DbFactory(Func<ApplicationDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    #endregion // Constructor


    #region Methods

    public void Dispose(bool disposing)
    {
        if (!_disposed && _dbContext != null)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion // Methods
}