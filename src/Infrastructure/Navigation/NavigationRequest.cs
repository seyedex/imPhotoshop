using imPhotoshop.Application.Common.Interfaces.Shell;
using imPhotoshop.Application.Common.Interfaces.Navigation;

namespace imPhotoshop.Infrastructure.Navigation;

internal class NavigationRequest<T> : INavigationRequest<T>
{
    private readonly Lazy<T> _viemodel;
    private readonly IShell _shell;

    public NavigationRequest(Func<T> viemodelFactory, IShell shell)
    {
        _viemodel = new Lazy<T>(viemodelFactory);
        _shell = shell;
    }

    public T Screen => _viemodel.Value; 

    public void Go()
    {
        _shell.ActivateItem(_viemodel.Value);
    }
}
