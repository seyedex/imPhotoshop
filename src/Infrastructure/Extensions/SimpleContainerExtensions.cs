using Caliburn.Micro;
using imPhotoshop.Infrastructure.Data;
using imPhotoshop.Infrastructure.Navigation;
using imPhotoshop.Infrastructure.Collections;
using imPhotoshop.Application.Common.Interfaces.Data;
using imPhotoshop.Application.Common.Interfaces.Shell;
using imPhotoshop.Application.Common.Interfaces.Navigation;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.Infrastructure.Extensions;

internal static class SimpleContainerExtensions
{
    public static SimpleContainer AddRepositories(this SimpleContainer container)
    {
        return container.Singleton<IUserRepository, UserRepository>();
    }

    public static SimpleContainer AddDatabase(this SimpleContainer container)
    {
        return container.Singleton<ApplicationDbContext>()
                        .Singleton<DbFactory>()
                        .Singleton<IUnitOfWork, UnitOfWork>();
    }

    public static SimpleContainer AddServices(this SimpleContainer container)
    {
        container.Instance<Lazy<IShell>>(new Lazy<IShell>(() => container.GetInstance<IShell>()));

        return container.Singleton<INavigator, Navigator>()
                        .Singleton<ICommandHistory, CommandHistory>();
    }
}