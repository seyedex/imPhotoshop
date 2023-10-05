
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Collections;
using imPhotoshop.WPF.Core.Interfaces.Navigation;
using imPhotoshop.WPF.Core.Interfaces.Shell;

namespace imPhotoshop.WPF.ViewModels;

public class ShellViewModel : Conductor<object>, IShell
{
    private readonly INavigator _navigator;
    private readonly ICommandHistory _commandHistory;
    private readonly WorkspaceViewModel _workspaceViewModel;
    private readonly ToolPanelViewModel _toolPanelViewModel;

    public WorkspaceViewModel Workspace => _workspaceViewModel;
    public ToolPanelViewModel ToolPanel => _toolPanelViewModel;

    public ShellViewModel(INavigator navigator,
                          ICommandHistory commandHistory,
                          ToolPanelViewModel toolPanelViewModel,
                          WorkspaceViewModel workspaceViewModel)
    {
        _navigator = navigator;
        _commandHistory = commandHistory;
        _toolPanelViewModel = toolPanelViewModel;
        _workspaceViewModel = workspaceViewModel;
    }

    protected override void OnViewLoaded(object view)
    {
        base.OnViewLoaded(view);
        _navigator.To<CanvasViewModel>().Go();
    }
}
