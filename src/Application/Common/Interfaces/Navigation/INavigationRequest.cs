
namespace imPhotoshop.Application.Common.Interfaces.Navigation;

public interface INavigationRequest<out T>
{
    T Screen { get; }
    void Go();
}
