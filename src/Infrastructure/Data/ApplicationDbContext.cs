using imPhotoshop.Application.Common.Interfaces.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace imPhotoshop.Infrastructure.Data;

internal class ApplicationDbContext : DbContext
{
    #region Variables

    private readonly IConfiguration _configuration;

    #endregion // Variables


    #region Properties

    public IUserRepository Users { get; set; }

    #endregion // Properties


    #region Constructor

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    #endregion // Constructor


    #region Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("Default");
        optionsBuilder.UseSqlite(connectionString);
    }

    #endregion // Methods
}