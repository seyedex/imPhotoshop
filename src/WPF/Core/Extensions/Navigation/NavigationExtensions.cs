using imPhotoshop.WPF.Core.Interfaces.Navigation;
using imPhotoshop.WPF.Models.Navigation;

namespace imPhotoshop.WPF.Core.Extensions.Navigation;

public static class NavigationExtensions
{
    public static INavigationRequest<T> WithArguments<T, TArgs>(this INavigationRequest<T> request, TArgs args)
        where T : IAcceptArguments<TArgs>
    {
        return new NavigationRequestWithArguments<T, TArgs>(request, args);
    }
}
