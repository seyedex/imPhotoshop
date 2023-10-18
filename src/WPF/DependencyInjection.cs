using Caliburn.Micro;
using imPhotoshop.WPF.ViewModels;
using imPhotoshop.Application.Common.Interfaces.Shell;

namespace imPhotoshop.WPF;

public static class DependencyInjection
{
    public static SimpleContainer AddWPFServices(this SimpleContainer container)
    {
        container.Singleton<CanvasViewModel>()
                  .Singleton<ToolPanelViewModel>()
                  .Singleton<LayersViewModel>()
                  .Singleton<WorkspaceViewModel>()
                  .Singleton<IShell, ShellViewModel>();

        return container;
    }
}
