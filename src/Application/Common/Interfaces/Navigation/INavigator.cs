
namespace imPhotoshop.Application.Common.Interfaces.Navigation;

public interface INavigator
{
    INavigationRequest<T> To<T>();
}
