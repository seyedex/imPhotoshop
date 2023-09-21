
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Navigation;
using imPhotoshop.WPF.Core.Interfaces.Shell;

namespace imPhotoshop.WPF.ViewModels;

public class ShellViewModel : Conductor<object>, IShell
{
    private readonly WorkspaceViewModel _workspaceViewModel;
    private readonly ToolPanelViewModel _toolPanelViewModel;

    public WorkspaceViewModel Workspace => _workspaceViewModel;
    public ToolPanelViewModel ToolPanel => _toolPanelViewModel;

    public ShellViewModel(ToolPanelViewModel toolPanelViewModel, WorkspaceViewModel workspaceViewModel)
    {
        _toolPanelViewModel = toolPanelViewModel;
        _workspaceViewModel = workspaceViewModel;
    }

    protected override async void OnViewLoaded(object view)
    {
        base.OnViewLoaded(view);
        var navigator = IoC.Get<INavigator>();
        await navigator.NavigateAsync<CanvasViewModel>();
    }
}
