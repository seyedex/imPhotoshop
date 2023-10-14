
using Caliburn.Micro;
using System.Windows;
using System.Windows.Input;
using imPhotoshop.WPF.Core.Helpers;
using imPhotoshop.WPF.Models.Drawing;
using imPhotoshop.WPF.Models.Commands;
using imPhotoshop.WPF.Core.Interfaces.Tools;
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using imPhotoshop.WPF.Core.Extensions.Commands;
using imPhotoshop.WPF.Core.Interfaces.Mediators;
using imPhotoshop.WPF.Core.Interfaces.Collections;
using imPhotoshop.WPF.Core.Interfaces.Navigation;
using System.Windows.Controls;

namespace imPhotoshop.WPF.ViewModels;

public class CanvasViewModel : Screen, IAcceptArguments<Image>
{
    #region Variables

    private readonly ICommandHistory _commandHistory;
    private readonly IToolMediator _toolMediator;
    private readonly ILayersMediator _layersMediator;
    private readonly ILayerCollection _layerCollection;
    private readonly IDrawingOptions _drawingOptions = new DrawingOptions();

    #endregion // Variables



    #region Properties

    public BindableCollection<ILayer> Layers => _layerCollection.ToBindableCollection();

    public ILayer? SelectedLayer { get; private set; }

    public UIElement? CurrentElement { get; set; }

    public ITool? CurrentTool { get; set; }

    #endregion // Properties



    #region Constructor

    public CanvasViewModel(ICommandHistory commandHistory,
                           IToolMediator toolMediator,
                           ILayersMediator layersMediator,
                           ILayerCollection layerCollection)
    {
        _commandHistory = commandHistory;

        _toolMediator = toolMediator;
        _toolMediator.ActiveToolChanged += ToolMediator_ActiveToolChanged;

        _layersMediator = layersMediator;
        _layersMediator.ActiveLayerChanged += LayersMediator_ActiveLayerChanged;

        _layerCollection = layerCollection;
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
            if (_commandHistory.Top is DrawCommand drawCommand)
            {
                drawCommand.Redraw(CurrentElement, CurrentTool, _drawingOptions);
            }
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
