
namespace imPhotoshop.WPF.Core.Interfaces.Navigation;

public interface IAcceptArguments<in T>
{
    void Accept(T args);
}
