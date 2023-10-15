
namespace imPhotoshop.WPF.Core.Interfaces.Navigation;

public interface INavigator
{
    INavigationRequest<T> To<T>();
}
