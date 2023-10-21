using Caliburn.Micro;

namespace imPhotoshop.WPF.ViewModels;

public class MainViewModel : Screen
{
    #region Variables

    private readonly ToolPanelViewModel _toolPanelViewModel;
    private readonly CanvasViewModel _canvasViewModel;
    private readonly WorkspaceViewModel _workspaceViewModel;

    #endregion // Variables


    #region Properties

    public ToolPanelViewModel ToolPanel => _toolPanelViewModel;
    public CanvasViewModel Canvas => _canvasViewModel;
    public WorkspaceViewModel Workspace => _workspaceViewModel;

    #endregion // Properties


    #region Constructor

    public MainViewModel(ToolPanelViewModel toolPanelViewModel,
                         CanvasViewModel canvasViewModel,
                         WorkspaceViewModel workspaceViewModel)
    {
        _toolPanelViewModel = toolPanelViewModel;
        _canvasViewModel = canvasViewModel;
        _workspaceViewModel = workspaceViewModel;
    }

    #endregion // Constructor


    #region Methods
    #endregion // Methods
}