using Caliburn.Micro;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using imPhotoshop.Application.Commands;
using imPhotoshop.Application.Common.Helpers;
using imPhotoshop.Application.Extensions.Commands;
using imPhotoshop.Application.Common.Interfaces.Tools;
using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Mediators;
using imPhotoshop.Application.Common.Interfaces.Navigation;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.WPF.ViewModels;

public class CanvasViewModel : Screen, IAcceptArguments<Image>
{
    #region Variables

    private readonly ICommandHistory _commandHistory;
    private readonly IToolMediator _toolMediator;
    private readonly ILayerMediator _layersMediator;
    private readonly IObservableLayerCollection _layerCollection;
    private readonly IDrawingOptions _drawingOptions;

    #endregion // Variables


    #region Properties

   public ObservableCollection<ILayer> Layers => _layerCollection.ObservableItems;

    public ILayer? SelectedLayer { get; private set; }

    public UIElement? CurrentElement { get; set; }

    public ITool? CurrentTool { get; set; }

    #endregion // Properties


    #region Constructor

    public CanvasViewModel(ICommandHistory commandHistory,
                           IToolMediator toolMediator,
                           ILayerMediator layersMediator,
                           IObservableLayerCollection layerCollection,
                           IDrawingOptions drawingOptions)
    {
        _commandHistory = commandHistory;

        _toolMediator = toolMediator;
        _toolMediator.ActiveItemChanged += ToolMediator_ActiveToolChanged;

        _layersMediator = layersMediator;
        _layersMediator.ActiveItemChanged += LayersMediator_ActiveLayerChanged;

        _layerCollection = layerCollection;

        _drawingOptions = drawingOptions;
    }

    #endregion // Constructor


    #region Methods

    public void Accept(Image image)
    {
        SelectedLayer?.AddElement(image);
    }

    #endregion // Methods


    #region EventHandlers

    public void Canvas_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            if (SelectedLayer == null)
            {
                MessageBox.Show("Select layer");
                return;
            }

            _drawingOptions.StartPosition = CursorHelper.GetRelativePosition(sender, e);
            _drawingOptions.EndPosition = _drawingOptions.StartPosition;
            CurrentElement = CurrentTool?.CreateElement(_drawingOptions);
            _commandHistory.Execute(new DrawCommand(SelectedLayer, CurrentElement));
        }
    }
    
    public void Canvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            _drawingOptions.EndPosition = CursorHelper.GetRelativePosition(sender, e);
            
            if (_commandHistory.Top is not DrawCommand drawCommand) return;
            if (CurrentTool is not IRedrawingTool redrawingTool) return;

            drawCommand.Redraw(CurrentElement, redrawingTool, _drawingOptions);
        }
    }

    public void Canvas_MouseUp(object sender, MouseEventArgs e)
    {
    }

    private void ToolMediator_ActiveToolChanged(ITool tool)
    {
        CurrentTool = tool;
    }

    private void LayersMediator_ActiveLayerChanged(ILayer layer)
    {
        SelectedLayer = layer;
    }

    #endregion // EventHandlers
}
