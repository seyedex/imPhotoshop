﻿
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Helpers;
using imPhotoshop.WPF.Core.Interfaces.Collections;
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using imPhotoshop.WPF.Core.Interfaces.Mediators;
using imPhotoshop.WPF.Models.Commands;

namespace imPhotoshop.WPF.ViewModels;

public class LayersViewModel : Screen
{
    private readonly ICommandHistory _commandHistory;
    private readonly ILayersMediator _layersMediator;
    private readonly ILayerCollection _layerCollection;
    private ILayer? _selectedLayer = null;

    public BindableCollection<ILayer> Layers => _layerCollection.ToBindableCollection();

    public ILayer? SelectedLayer
    {
        get => _selectedLayer;
        set
        {
            _selectedLayer = value;
            _layersMediator.ChangeActiveLayer(value);
            NotifyOfPropertyChange(() => SelectedLayer);
        }
    }

    public LayersViewModel(ICommandHistory commandHistory,
                           ILayersMediator layersMediator,
                           ILayerCollection layerCollection)
    {
        _commandHistory = commandHistory;
        _layersMediator = layersMediator;
        _layerCollection = layerCollection;
    }

    public void CreateLayer()
    {
        var newLayer = LayersHelper.CreateLayer();
        _commandHistory.Execute(new AddLayerCommand(_layerCollection, newLayer));
    }

    public void DeleteLayer()
    {
        _commandHistory.Undo();
        //_commandHistory.Execute(new DeleteLayerCommand(_layers, SelectedLayer));
    }
}
