
namespace imPhotoshop.Application.Common.Interfaces.Commands;

public interface ICommand
{
    void Execute();
    void Undo();
}
