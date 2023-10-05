
using imPhotoshop.WPF.Core.Interfaces.Tools;
using System;

namespace imPhotoshop.WPF.Core.Interfaces.Mediators;

public interface IToolMediator
{
    public event Action<ITool> ActiveToolChanged;

    public void ChangeActiveTool(ITool tool);
}
