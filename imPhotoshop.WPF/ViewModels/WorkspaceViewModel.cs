
using Caliburn.Micro;

namespace imPhotoshop.WPF.ViewModels;

public class WorkspaceViewModel : Screen
{
    private readonly LayersViewModel _layersViewModel;
    
    public LayersViewModel Layers => _layersViewModel;

    public WorkspaceViewModel(LayersViewModel layersViewModel)
    {
        _layersViewModel = layersViewModel;
    }
}
