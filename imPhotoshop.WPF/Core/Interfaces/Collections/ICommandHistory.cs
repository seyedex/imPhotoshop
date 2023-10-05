using imPhotoshop.WPF.Core.Interfaces.Commands;

namespace imPhotoshop.WPF.Core.Interfaces.Collections;

public interface ICommandHistory
{
    public ICommand Top { get; }

    public void Execute(ICommand command);
    public void Undo();
    public void Redo();
}
