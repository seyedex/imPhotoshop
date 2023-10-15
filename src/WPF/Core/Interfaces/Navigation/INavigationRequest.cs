
namespace imPhotoshop.WPF.Core.Interfaces.Navigation;

public interface INavigationRequest<out T>
{
    T Screen { get; }
    void Go();
}
