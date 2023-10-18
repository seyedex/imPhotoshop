using imPhotoshop.Application.Common.Interfaces.Commands;

namespace imPhotoshop.Application.Common.Interfaces.Collections;

public interface ICommandHistory
{
    public ICommand Top { get; }

    public void Execute(ICommand command);
    public void Undo();
    public void Redo();
    public void Clear();
}
