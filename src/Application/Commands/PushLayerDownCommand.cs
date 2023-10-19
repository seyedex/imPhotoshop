using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Commands;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.Application.Commands;

public class PushLayerDownCommand : ICommand
{
    private readonly ILayerCollection _layers;
    private readonly ILayer _layerToPush;
    private readonly int _startIndex;

    public PushLayerDownCommand(ILayerCollection layers, ILayer layerToPush)
    {
        _layers = layers;
        _layerToPush = layerToPush;
        _startIndex = _layers.IndexOf(_layerToPush);
    }

    public void Execute()
    {
        if (_startIndex >= _layers.Count) return;

        _layers.Remove(_layerToPush);
        _layers.Insert(_startIndex + 1, _layerToPush);
    }

    public void Undo()
    {
        _layers.Remove(_layerToPush);
        _layers.Insert(_startIndex, _layerToPush);
    }
}
