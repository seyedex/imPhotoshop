
namespace imPhotoshop.Application.Common.Interfaces.Mediators;

public interface IMediator<T>
{
    public event Action<T> ActiveItemChanged;

    public void ChangeActiveItem(T obj);
}
