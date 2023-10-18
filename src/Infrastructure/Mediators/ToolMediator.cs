using imPhotoshop.Application.Common.Interfaces.Mediators;
using imPhotoshop.Application.Common.Interfaces.Tools;

namespace imPhotoshop.Infrastructure.Mediators;

internal class ToolMediator : IToolMediator
{
    public event Action<ITool> ActiveItemChanged;

    public void ChangeActiveItem(ITool tool)
    {
        ActiveItemChanged?.Invoke(tool);
    }
}
