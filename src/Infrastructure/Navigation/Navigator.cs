using Caliburn.Micro;
using imPhotoshop.Application.Common.Interfaces.Navigation;
using imPhotoshop.Application.Common.Interfaces.Shell;

namespace imPhotoshop.Infrastructure.Navigation;

internal class Navigator : INavigator
{
    private readonly Lazy<IShell> _shell;
    private readonly SimpleContainer _container;

    private IShell Shell => _shell.Value;

    public Navigator(Lazy<IShell> shell, SimpleContainer container)
    {
        _shell = shell;
        _container = container;
    }

    public INavigationRequest<T> To<T>()
    {
        var viewModelFactory = () => _container.GetInstance<T>();
        return new NavigationRequest<T>(viewModelFactory, Shell);
    }
}
