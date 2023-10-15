
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Navigation;
using imPhotoshop.WPF.Core.Interfaces.Shell;
using System;

namespace imPhotoshop.WPF.Models.Navigation;

public class Navigator : INavigator
{
    private readonly Lazy<IShell> _shell;

    private IShell Shell => _shell.Value;

    public Navigator(Lazy<IShell> shell)
    {
        _shell = shell;
    }

    public INavigationRequest<T> To<T>()
    {
        return new NavigationRequest<T>(() => IoC.Get<T>(), Shell);
    }
}
