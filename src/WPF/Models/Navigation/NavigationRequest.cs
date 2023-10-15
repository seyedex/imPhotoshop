
using imPhotoshop.WPF.Core.Interfaces.Navigation;
using imPhotoshop.WPF.Core.Interfaces.Shell;
using System;

namespace imPhotoshop.WPF.Models.Navigation;

public class NavigationRequest<T> : INavigationRequest<T>
{
    private readonly Lazy<T> _viemodel;
    private readonly IShell _shell;

    public NavigationRequest(Func<T> viemodelFactory, IShell shell)
    {
        _viemodel = new Lazy<T>(viemodelFactory);
        _shell = shell;
    }

    public T Screen { get { return _viemodel.Value; } }

    public async void Go()
    {
        await _shell.ActivateItemAsync(_viemodel.Value);
    }
}
