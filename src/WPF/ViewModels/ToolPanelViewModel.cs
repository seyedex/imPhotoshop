
using Caliburn.Micro;
using HandyControl.Controls;
using HandyControl.Tools;
using imPhotoshop.WPF.Core.Interfaces.Mediators;
using imPhotoshop.WPF.Core.Interfaces.Tools;
using imPhotoshop.WPF.Models.Tools;

namespace imPhotoshop.WPF.ViewModels;

public class ToolPanelViewModel : Screen
{
    #region Variables

    private readonly IToolMediator _toolMediator;
    private ITool? _selectedTool;
    private bool _brushToolChecked;
    private bool _lineToolChecked;
    private bool _eraserToolChecked;

    #endregion // Variables



    #region Constructor

    public ToolPanelViewModel(IToolMediator toolMediator)
    {
        _toolMediator = toolMediator;
        BrushToolChecked = true;
    }

    #endregion // Constructor



    #region Properties

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

    public bool EraserToolChecked
    {
        get => _eraserToolChecked;
        set
        {
            _eraserToolChecked = value;
            if (value)
            {
                SelectedTool = new EraserTool();
            }
            NotifyOfPropertyChange(() => EraserToolChecked);
        }
    }

    #endregion // Properties



    #region Methods

    public void OpenColorPicker()
    {
        var picker = SingleOpenHelper.CreateControl<ColorPicker>();
        var window = new PopupWindow
        {
            PopupElement = picker
        };
        picker.SelectedColorChanged += delegate { window.Close(); };
        picker.Canceled += delegate { window.Close(); };
        window.Show();
    }

    #endregion
}
