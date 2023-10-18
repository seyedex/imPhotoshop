
namespace imPhotoshop.Application.Common.Interfaces.Navigation;

public interface IAcceptArguments<in T>
{
    void Accept(T args);
}
