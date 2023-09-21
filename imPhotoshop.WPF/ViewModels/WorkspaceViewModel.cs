
using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows.Controls;

namespace imPhotoshop.WPF.ViewModels;

public class WorkspaceViewModel : Screen
{
    private BindableCollection<Canvas> _layers = new();
    private Canvas _selectedLayer;

    protected override void OnViewLoaded(object view)
    {
        base.OnViewLoaded(view);
        _layers.AddRange(new List<Canvas>{ new Canvas(), new Canvas()});
    }

    public BindableCollection<Canvas> Layers
    {
        get => _layers;
        set => _layers = value;
    }

    public Canvas SelectedLayer
    {
        get
        {
            return _selectedLayer;
        }
        set
        {
            _selectedLayer = value;
            NotifyOfPropertyChange(() => SelectedLayer);
        }
    }
}
