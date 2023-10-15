
using System;
using imPhotoshop.WPF.Core.Interfaces.Mediators;
using imPhotoshop.WPF.Core.Interfaces.Tools;

namespace imPhotoshop.WPF.Models.Mediators;

public class ToolMediator : IToolMediator
{
    public event Action<ITool> ActiveToolChanged;

    public void ChangeActiveTool(ITool tool)
    {
        ActiveToolChanged?.Invoke(tool);
    }
}
