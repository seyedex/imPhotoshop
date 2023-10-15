
using imPhotoshop.WPF.Core.Interfaces.Navigation;

namespace imPhotoshop.WPF.Models.Navigation;

public class NavigationRequestWithArguments<T, TArgs> : INavigationRequest<T> where T : IAcceptArguments<TArgs>
{
    private readonly INavigationRequest<T> _request;
    private readonly TArgs _args;

    public NavigationRequestWithArguments(INavigationRequest<T> request, TArgs args)
    {
        _request = request;
        _args = args;
    }

    public T Screen { get => _request.Screen; } 

    public void Go()
    {
        _request.Screen.Accept(_args);
        _request.Go();
    }
}
