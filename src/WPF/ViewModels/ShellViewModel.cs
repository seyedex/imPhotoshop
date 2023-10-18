using Caliburn.Micro;
using Microsoft.Win32;
using imPhotoshop.Application.Common.Helpers;
using imPhotoshop.Application.Common.Interfaces.Shell;
using imPhotoshop.Application.Common.Interfaces.Navigation;
using imPhotoshop.Application.Common.Interfaces.Collections;

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

    public void ActivateItem(object item)
    {
        ActivateItemAsync(item);
    }

    public void Undo()
    {
        _commandHistory.Undo();
    }

    public void Redo()
    {
        _commandHistory.Redo();
    }

    public void PlaceImage()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Images (*.jpg;*.png)|*.jpg;*.png|All files (*.*)|*.*";
        openFileDialog.ShowDialog();

        if (openFileDialog.FileName == string.Empty) return;

        var image = ImageHelper.GetImage(openFileDialog.FileName);
        _navigator.To<CanvasViewModel>().Screen.Accept(image);
    }
}
