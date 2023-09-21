
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Navigation;
using imPhotoshop.WPF.Core.Interfaces.Shell;
using System.Threading.Tasks;

namespace imPhotoshop.WPF.Models.Navigation;

public class Navigator : INavigator
{
    private readonly IShell _shell;

    public Navigator(IShell shell)
    {
        _shell = shell;
    }

    public async Task NavigateAsync<T>()
    {
        var screen = IoC.Get<T>();
        await _shell.ActivateItemAsync(screen);
    }
}
