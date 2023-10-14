
using System;
using System.Collections.Generic;
using imPhotoshop.WPF.Core.Interfaces.Collections;
using imPhotoshop.WPF.Core.Interfaces.Commands;

namespace imPhotoshop.WPF.Core.Collections;

public class CommandHistory : ICommandHistory
{
    private List<ICommand> _history = new();
    private int _currentIndex = -1;

    public ICommand? Top
    {
        get
        {
            try
            {
                return _history[_currentIndex];
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
    }

    public void Execute(ICommand command)
    {
        if (_currentIndex != _history.Count - 1)
        {
            int nextCommandIndex = _currentIndex + 1;
            int commandsToDeleteCount = _history.Count - _currentIndex - 1;
            _history.RemoveRange(nextCommandIndex, commandsToDeleteCount);
        }
        _history.Add(command);
        _currentIndex++;
        command.Execute();
    }

    public void Undo()
    {
        if (_currentIndex > -1)
        {
            _history[_currentIndex].Undo();
            _currentIndex--;
        }
    }

    public void Redo()
    {
        if (CanExecuteNextCommand())
        {
            _currentIndex++;
            _history[_currentIndex].Execute();
        }
    }

    public void Clear()
    {
        _history.Clear();
        _currentIndex = -1;
    }

    private bool CanExecuteNextCommand()
    {
        return _currentIndex + 1 < _history.Count;
    }
}
