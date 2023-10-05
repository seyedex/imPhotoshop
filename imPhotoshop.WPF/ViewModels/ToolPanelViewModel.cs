
using Caliburn.Micro;
using imPhotoshop.WPF.Core.Interfaces.Mediators;
using imPhotoshop.WPF.Core.Interfaces.Tools;
using imPhotoshop.WPF.Models.Tools;

namespace imPhotoshop.WPF.ViewModels;

public class ToolPanelViewModel : Screen
{
    private readonly IToolMediator _toolMediator;
    private ITool? _selectedTool;
    private bool _brushToolChecked;
    private bool _lineToolChecked;

    public ToolPanelViewModel(IToolMediator toolMediator)
    {
        _toolMediator = toolMediator;
    }

    public ITool? SelectedTool
    {
        get
        {
            return _selectedTool;
        }
        set
        {
            _selectedTool = value;
            _toolMediator.ChangeActiveTool(value);
            NotifyOfPropertyChange(() => SelectedTool);
        }
    }

    public bool BrushToolChecked
    {
        get => _brushToolChecked;
        set
        {
            _brushToolChecked = value;
            if (value)
            {
                SelectedTool = new BrushTool();
            }
            NotifyOfPropertyChange(() => BrushToolChecked);
        }
    }

    public bool LineToolChecked
    {
        get => _lineToolChecked;
        set
        {
            _lineToolChecked = value;
            if (value)
            {
                SelectedTool = new LineTool();
            }
            NotifyOfPropertyChange(() => LineToolChecked);
        }
    }
}
