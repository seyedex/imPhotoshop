
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Navigation;
using imPhotoshop.WPF.Core.Interfaces.Shell;

namespace imPhotoshop.WPF.Models.Navigation;

public class Navigator : INavigator
{
    private IShell _shell;

    public Navigator(IShell shell)
    {
        _shell = shell;
    }

    public async void Navigate<T>()
    {
        var screen = IoC.Get<T>();
        await _shell.ActivateItemAsync(screen);
    }
}
