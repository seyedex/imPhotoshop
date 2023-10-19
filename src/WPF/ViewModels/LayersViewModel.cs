using Caliburn.Micro;
using System.Collections.ObjectModel;
using imPhotoshop.Application.Commands;
using imPhotoshop.WPF.Infrastructure.Helpers;
using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Mediators;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.WPF.ViewModels;

public class LayersViewModel : Screen
{
    private readonly ICommandHistory _commandHistory;
    private readonly ILayerMediator _layersMediator;
    private readonly IObservableLayerCollection _layerCollection;
    private ILayer? _selectedLayer = null;

    public ObservableCollection<ILayer>? Layers => _layerCollection.ObservableItems;

    public ILayer? SelectedLayer
    {
        get => _selectedLayer;
        set
        {
            _selectedLayer = value;
            _layersMediator.ChangeActiveItem(value);
            NotifyOfPropertyChange(() => SelectedLayer);
        }
    }

    public LayersViewModel(ICommandHistory commandHistory,
                           ILayerMediator layersMediator,
                           IObservableLayerCollection layerCollection)
    {
        _commandHistory = commandHistory;
        _layersMediator = layersMediator;
        _layerCollection = layerCollection;
    }

    public void CreateLayer()
    {
        var newLayer = LayerHelper.CreateLayer();
        var addLayerCommand = new AddLayerCommand(_layerCollection, newLayer);
        _commandHistory.Execute(addLayerCommand);
    }

    public void DeleteLayer()
    {
        var deleteLayerCommand = new DeleteLayerCommand(_layerCollection, SelectedLayer);
        _commandHistory.Execute(deleteLayerCommand);
    }

    public void PushLayerUp()
    {
        var pushLayerUpCommand = new PushLayerUpCommand(_layerCollection, SelectedLayer);
        _commandHistory.Execute(pushLayerUpCommand);
    }

    public void PushLayerDown()
    {
        var pushLayerDownCommand = new PushLayerDownCommand(_layerCollection, SelectedLayer);
        _commandHistory.Execute(pushLayerDownCommand);
    }
}
