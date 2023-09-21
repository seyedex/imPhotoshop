
using System.Threading.Tasks;

namespace imPhotoshop.WPF.Core.Interfaces.Navigation;

public interface INavigator
{
    Task NavigateAsync<T>();
}
